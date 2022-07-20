using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using GL_EditorFramework.GL_Core;
using GL_EditorFramework.Interfaces;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes.Objects;
using UAssetAPI.PropertyTypes.Structs;
using UAssetAPI.UnrealTypes;

namespace UE4MapEditor;

public class Actor : TransformableObject
{

    //I'll just put default values for the constructor because in the base they just set the transform
    //Also I don't have immediate access to the rootcomponent unless I pass it as an argument
    //Therefore the best is to do it in the constructor
    public Actor(NormalExport export) : base(Vector3.Zero, Vector3.Zero, Vector3.One)
    {
        this.export = export;
        name = export.ObjectName.Value.Value;
        //There's no common pattern for finding RootComponents except they are near the end of the data
        RootComponent = null;
        for (int i = export.Data.Count - 1; i >= 0; i--)
            if (export.Data[i].Name.Value.Value == "RootComponent")
                RootComponent = (NormalExport)export.Asset.Exports[((ObjectPropertyData)export.Data[i]).Value.Index];
        HandleTransforms();
    }

    void HandleTransforms()
    {
        //¯\_(ツ)_/¯ It happens for the default export and don't really know how to deal with it
        if (RootComponent is null) return;
        bool HasLocation, HasRotation, HasScale;
        HasLocation = HasRotation = HasScale = false;
        //Changing this to all be in one function is also a lot more optimised
        for (int i = 0; i < RootComponent.Data.Count; i++)
            switch (RootComponent.Data[i].Name.Value.Value)
            {
                //casting because it will always be that
                case "RelativeLocation":
                    Position = ToVector3((VectorPropertyData)((StructPropertyData)RootComponent.Data[i]).Value[0]);
                    HasLocation = true;
                    break;
                case "RelativeRotation":
                    HasRotation = true;
                    Rotation = ToVector3((RotatorPropertyData)((StructPropertyData)RootComponent.Data[i]).Value[0]);
                    break;
                case "RelativeScale3D":
                    HasScale = true;
                    Scale = ToVector3((VectorPropertyData)((StructPropertyData)RootComponent.Data[i]).Value[0]);
                    break;
            }

        #region default struct creation
        if (!HasLocation)
        {
            StructPropertyData RelativeLocation = new StructPropertyData(FName.FromString(RootComponent.Asset, "RelativeLocation"), FName.FromString(RootComponent.Asset, "Vector"));
            RelativeLocation.Value.Add(new VectorPropertyData(FName.FromString(RootComponent.Asset, "RelativeLocation")) { Value = new(0, 0, 0) });
            RootComponent.Data.Add(RelativeLocation);
        }
        if (!HasRotation)
        {
            StructPropertyData RelativeRotation = new StructPropertyData(FName.FromString(RootComponent.Asset, "RelativeRotation"), FName.FromString(RootComponent.Asset, "Rotator"));
            RelativeRotation.Value.Add(new RotatorPropertyData(FName.FromString(RootComponent.Asset, "RelativeRotation")) { Value = new(0, 0, 0) });
            RootComponent.Data.Add(RelativeRotation);
        }
        if (!HasScale)
        {
            StructPropertyData RelativeScale3D = new StructPropertyData(FName.FromString(RootComponent.Asset, "RelativeScale3D"), FName.FromString(RootComponent.Asset, "Vector"));
            RelativeScale3D.Value.Add(new VectorPropertyData(FName.FromString(RootComponent.Asset, "RelativeScale3D")) { Value = new(1, 1, 1) });
            RootComponent.Data.Add(RelativeScale3D);
        }
        #endregion
    }

    public NormalExport export;

    NormalExport? RootComponent;

    string name;

    public override string ToString() => name;

    static Vector3 ToVector3(VectorPropertyData Vector) =>
        new Vector3(Vector.Value.X / 100, Vector.Value.Y / 100, Vector.Value.Z / 100);

    static Vector3 ToVector3(RotatorPropertyData Rotator) =>
        new Vector3(Rotator.Value.Roll, Rotator.Value.Pitch, Rotator.Value.Yaw);

    static FVector ToFVector(Vector3 Vector) =>
        new FVector(Vector.X * 100, Vector.Y * 100, Vector.Z * 100);

    static FRotator ToFRotator(Vector3 Rotator) =>
        new FRotator(Rotator.X, Rotator.Y, Rotator.Z);

    #region user interface
    public override bool TrySetupObjectUIControl(EditorSceneBase scene, ObjectUIControl objectUIControl)
    {
        if (!Selected) return false;
        if (RootComponent is not null)
            //for that one specific case :/
            objectUIControl.AddObjectUIContainer(new TransformPropertyProvider(this, scene, RootComponent), "Transform");
        objectUIControl.AddObjectUIContainer(new ActorUIControl(scene, export), "Properties");
        return true;
    }

    struct ActorUIControl : IObjectUIContainer
    {
        EditorSceneBase scene;
        NormalExport export;

        public ActorUIControl(EditorSceneBase scene, NormalExport export)
        {
            this.scene = scene;
            this.export = export;
        }

        //How should I handle references to other objects?
        public void DoUI(IObjectUIControl control)
        {
            foreach (var data in export.Data)
                AssignValue(data, control);
        }

        void AssignValue(PropertyData data, IObjectUIControl control)
        {
            string name = data.Name.Value.Value;
            switch (data)
            {
                #region collection inputs
                case ArrayPropertyData ArrayProperty:
                    //We aren't particularly interested in these
                    if (name == "BlueprintCreatedComponents" || name == "UCSModifiedProperties") break;
                    foreach (var item in ArrayProperty.Value) AssignValue(item, control);
                    break;

                case MapPropertyData MapProperty:
                    foreach (var item in MapProperty.Value)
                    {
                        //AssignValue(item.Key, control);
                        AssignValue(item.Value, control);
                    }
                    break;

                case StructPropertyData StructProperty:
                    if (name == "RelativeLocation" || name == "RelativeRotation" || name == "RelativeScale3D") break;
                    foreach (var item in StructProperty.Value) AssignValue(item, control);
                    break;

                case BoxPropertyData BoxProperty:
                    foreach (var vector in BoxProperty.Value) AssignValue(vector, control);
                    break;


                case Box2DPropertyData Box2DProperty:
                    foreach (var vector2D in Box2DProperty.Value) AssignValue(vector2D, control);
                    break;
                #endregion

                #region text properties
                case EnumPropertyData EnumProperty:
                    EnumProperty.Value = FName.FromString(export.Asset, control.TextInput(EnumProperty.Value.ToString(), name));
                    break;

                case NamePropertyData NameProperty:
                    NameProperty.Value = FName.FromString(export.Asset, control.TextInput(NameProperty.Value.ToString(), name));
                    break;

                case TextPropertyData TextProperty:
                    TextProperty.Value = FString.FromString(control.TextInput(TextProperty.Value.ToString(), name));
                    break;

                case StrPropertyData StrProperty:
                    StrProperty.Value = FString.FromString(control.TextInput(StrProperty.Value.ToString(), name));
                    break;

                case BytePropertyData ByteProperty:
                    if (ByteProperty.ByteType == BytePropertyType.FName)
                    {
                        //not sure how to handle enum type...maybe just another addnameref replacing "::NewEnumerator1" with ""
                        //Because if they edit the enum that's being used a name map ref also needs to be changed
                        ByteProperty.EnumValue = FName.FromString(export.Asset, export.Asset.GetNameReference(export.Asset.AddNameReference(FString.FromString(control.TextInput(ByteProperty.EnumValue.Value.Value, name)))).Value);
                        break;
                    }
                    ByteProperty.Value = (byte)control.NumberInput(ByteProperty.Value, name);
                    break;
                #endregion

                #region number properties
                case Int8PropertyData Int8Property:
                    Int8Property.Value = (sbyte)control.NumberInput(Int8Property.Value, name);
                    break;

                case Int16PropertyData Int16Property:
                    Int16Property.Value = (short)control.NumberInput(Int16Property.Value, name);
                    break;

                case IntPropertyData IntProperty:
                    IntProperty.Value = (int)control.NumberInput(IntProperty.Value, name);
                    break;

                case Int64PropertyData Int64Property:
                    Int64Property.Value = (long)control.NumberInput(Int64Property.Value, name);
                    break;

                case UInt16PropertyData UInt16Property:
                    UInt16Property.Value = (ushort)control.NumberInput(UInt16Property.Value, name);
                    break;

                case UInt32PropertyData UInt32Property:
                    UInt32Property.Value = (uint)control.NumberInput(UInt32Property.Value, name);
                    break;

                case UInt64PropertyData UInt64Property:
                    UInt64Property.Value = (ulong)control.NumberInput(UInt64Property.Value, name);
                    break;

                case FloatPropertyData FloatProperty:
                    FloatProperty.Value = control.NumberInput(FloatProperty.Value, name);
                    break;

                case DoublePropertyData DoubleProperty:
                    DoubleProperty.Value = control.NumberInput((float)DoubleProperty.Value, name);
                    break;
                #endregion

                case BoolPropertyData BoolProperty:
                    BoolProperty.Value = control.CheckBox(name, BoolProperty.Value);
                    break;

                #region vector properties
                case LinearColorPropertyData LinearColorProperty:
                    var ColourVector = new Vector3(LinearColorProperty.Value.R, LinearColorProperty.Value.G, LinearColorProperty.Value.B);
                    var pointer = control.FullWidthVector3Input(ColourVector, name);
                    LinearColorProperty.Value = new LinearColor(pointer.X, pointer.Y, pointer.Z, 1);
                    break;

                case ColorPropertyData ColorProperty:
                    var Vector = new Vector3(ColorProperty.Value.R, ColorProperty.Value.G, ColorProperty.Value.B);
                    var input = control.FullWidthVector3Input(Vector, name);
                    ColorProperty.Value = System.Drawing.Color.FromArgb(255, (int)input.X, (int)input.Y, (int)input.Z);
                    break;
                case VectorPropertyData VectorProperty:
                    VectorProperty.Value = ToFVector(control.FullWidthVector3Input(ToVector3(VectorProperty), name));
                    break;
                case RotatorPropertyData RotatorProperty:
                    RotatorProperty.Value = ToFRotator(control.FullWidthVector3Input(ToVector3(RotatorProperty), name));
                    break;
                case Vector2DPropertyData Vector2DProperty:
                    Vector2DProperty.X = control.NumberInput(Vector2DProperty.X, name);
                    Vector2DProperty.Y = control.NumberInput(Vector2DProperty.Y, name);
                    break;
                    #endregion
            }
        }

        public void OnValueChanged() => scene.Refresh();

        public void OnValueChangeStart() { }

        public void OnValueSet() { }

        public void UpdateProperties() { }
    }

    //PropertyProvider's function DoUI isn't virtual so I had to rewrite it to rewrite DoUI and link transforms
    struct TransformPropertyProvider : IObjectUIContainer
    {
        public TransformPropertyProvider(TransformableObject obj, EditorSceneBase scene, NormalExport root)
        {
            this.root = root;
            this.obj = obj;
            this.scene = scene;
        }

        EditorSceneBase.PropertyCapture? capture = null;

        NormalExport root; TransformableObject obj; EditorSceneBase scene;

        public void OnValueChanged() => scene.Refresh();

        public void DoUI(IObjectUIControl control)
        {
            foreach (var item in root.Data)
                switch (item.Name.Value.Value)
                {
                    case "RelativeLocation":
                        ((VectorPropertyData)((StructPropertyData)item).Value[0]).Value = ToFVector(
                        obj.Position = control.Vector3Input(obj.Position, "Position", 1f, 16));
                        break;
                    case "RelativeRotation":
                        ((RotatorPropertyData)((StructPropertyData)item).Value[0]).Value = ToFRotator(
                         obj.Rotation = control.Vector3Input(obj.Rotation, "Rotation", 5f, 2, -180f, 180f, wrapAround: true));
                        break;
                    case "RelativeScale3D":
                        ((VectorPropertyData)((StructPropertyData)item).Value[0]).Value = ToFVector(
                        obj.Scale = control.Vector3Input(obj.Scale, "Scale", 0.125f, 2));
                        break;
                }
        }

        public void UpdateProperties() { }

        public void OnValueChangeStart() => capture = new EditorSceneBase.PropertyCapture(obj);

        public void OnValueSet()
        {
            capture?.HandleUndo(scene);
            capture = null;
            scene.Refresh();
        }
    }
    #endregion

    #region rendering
    public override void Draw(GL_ControlModern control, Pass pass, EditorSceneBase editorScene)
    {
        switch (export.GetExportClassType().Value.Value)
        {
            //Since there are only 4 gizmos needed I need to remind myself to optimise rendering
            //Also just realised I don't have any UE4 games that use the native sound system :p
            case "Emitter":
                GizmoRenderer.Draw(new(0.5f, 0.5f), control, pass, Position, Selected && editorScene.Hovered == this ? hoverSelectColor : editorScene.Hovered == this ? hoverColor : Selected ? selectColor : Vector4.Zero);
                break;
            case "CameraActor":
                GizmoRenderer.Draw(new(0, 0), control, pass, Position, Selected && editorScene.Hovered == this ? hoverSelectColor : editorScene.Hovered == this ? hoverColor : Selected ? selectColor : Vector4.Zero);
                break;
            case "PointLight":
            case "SpotLight":
                GizmoRenderer.Draw(new(0.5f, 0), control, pass, Position, Selected && editorScene.Hovered == this ? hoverSelectColor : editorScene.Hovered == this ? hoverColor : Selected ? selectColor : Vector4.Zero);
                break;
            default:
                base.Draw(control, pass, editorScene);
                break;
        }
    }
    #endregion
}