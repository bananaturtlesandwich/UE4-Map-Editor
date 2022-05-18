using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace UE4MapEditor;

public class Actor : TransformableObject
{
    static Vector3 GetRelativeLocation(NormalExport export)
    {
        foreach (var item in export.Data)
            if (item.Name.Value.Value == "RelativeLocation")
                return ToVector3((VectorPropertyData)((StructPropertyData)item).Value[0]);
        //if doesn't exist make one so it can be edited
        StructPropertyData RelativeLocation = new StructPropertyData(FName.FromString("RelativeLocation"), FName.FromString("Vector"));
        RelativeLocation.Value.Add(new VectorPropertyData(FName.FromString("RelativeLocation")) { Value = new(0, 0, 0) });
        export.Data.Add(RelativeLocation);
        return Vector3.Zero;
    }

    static Vector3 GetRelativeRotation(NormalExport export)
    {
        foreach (var item in export.Data)
            if (item.Name.Value.Value == "RelativeRotation")
                return ToVector3((RotatorPropertyData)((StructPropertyData)item).Value[0]);
        //if doesn't exist make one so it can be edited
        StructPropertyData RelativeRotation = new StructPropertyData(FName.FromString("RelativeRotation"), FName.FromString("Rotator"));
        RelativeRotation.Value.Add(new RotatorPropertyData(FName.FromString("RelativeRotation")) { Value = new(0, 0, 0) });
        export.Data.Add(RelativeRotation);
        return Vector3.Zero;
    }

    static Vector3 GetRelativeScale3D(NormalExport export)
    {
        foreach (var item in export.Data)
            if (item.Name.Value.Value == "RelativeScale3D")
                return ToVector3((VectorPropertyData)((StructPropertyData)item).Value[0]);
        //if doesn't exist make one so it can be edited
        StructPropertyData RelativeScale3D = new StructPropertyData(FName.FromString("RelativeScale3D"), FName.FromString("Vector"));
        RelativeScale3D.Value.Add(new VectorPropertyData(FName.FromString("RelativeScale3D")) { Value = new(1, 1, 1) });
        export.Data.Add(RelativeScale3D);
        return Vector3.One;
    }

    public Actor(NormalExport export) : base(GetRelativeLocation(export), GetRelativeRotation(export), GetRelativeScale3D(export))
    {
        this.export = export;
        name = export.Asset.Exports[export.OuterIndex.Index].ObjectName.Value.Value;
    }

    public NormalExport export;

    string name = "";

    public override string ToString() => name;

    public override bool TrySetupObjectUIControl(EditorSceneBase scene, ObjectUIControl objectUIControl)
    {
        if (!Selected) return false;
        objectUIControl.AddObjectUIContainer(new UMapPropertyProvider(this, scene, export), "Transform");
        objectUIControl.AddObjectUIContainer(new ActorUIControl(scene, export), "Properties");
        return true;
    }

    static Vector3 ToVector3(VectorPropertyData Vector) =>
        new Vector3(Vector.Value.X, Vector.Value.Y, Vector.Value.Z);

    static Vector3 ToVector3(RotatorPropertyData Rotator) =>
        new Vector3(Rotator.Value.Pitch, Rotator.Value.Yaw, Rotator.Value.Roll);

    //FVector has no operator overload so this'll do for now
    static FVector ToFVector(Vector3 Vector) =>
        new FVector(Vector.X, Vector.Y, Vector.Z);

    static FRotator ToFRotator(Vector3 Rotator) =>
        new FRotator(Rotator.X, Rotator.Y, Rotator.Z);

    class ActorUIControl : IObjectUIContainer
    {
        EditorSceneBase scene;
        NormalExport export;

        public ActorUIControl(EditorSceneBase scene, NormalExport export)
        {
            this.scene = scene;
            this.export = export;
        }
        public void DoUI(IObjectUIControl control)
        {
            foreach (var data in ((NormalExport)export.Asset.Exports[export.OuterIndex.Index]).Data) AssignValue(data, control);
            //not in AssignValue because it would cause a stack overflow with objects referencing back to the original
            List<ObjectPropertyData> references = new();
            foreach (var data in ((NormalExport)export.Asset.Exports[export.OuterIndex.Index]).Data)
                if (data is ObjectPropertyData) references.Add((ObjectPropertyData)data);
            //Remove duplicate references
            for (int i = 0; i < references.Count; i++)
                for (int j = 0; j < references.Count; j++)
                    if (references[i].Value.Index == references[j].Value.Index) references.RemoveAt(j);
            foreach (ObjectPropertyData ObjectProperty in references)
            {
                if (ObjectProperty.Value.Index < 0) continue;
                control.Heading(export.Asset.Exports[ObjectProperty.Value.Index].ObjectName.Value.Value);
                foreach (var item in ((NormalExport)export.Asset.Exports[ObjectProperty.Value.Index]).Data)
                    AssignValue(item, control);
            }
        }

        void AssignValue(PropertyData data, IObjectUIControl control)
        {
            string name = data.Name.Value.Value;
            switch (data)
            {
                #region collection inputs
                case ArrayPropertyData ArrayProperty:
                    if (name == "BlueprintCreatedComponents" || name == "UCSModifiedProperties") break;
                    foreach (var item in ArrayProperty.Value) AssignValue(item, control);
                    break;

                case MapPropertyData MapProperty:
                    foreach (var item in MapProperty.Value)
                    {
                        AssignValue(item.Key, control);
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
                #endregion

                #region text properties
                case EnumPropertyData EnumProperty:
                    EnumProperty.Value = FName.FromString(control.TextInput(EnumProperty.Value.ToString(), name));
                    break;

                case NamePropertyData NameProperty:
                    NameProperty.Value = FName.FromString(control.TextInput(NameProperty.Value.ToString(), name));
                    break;

                case TextPropertyData TextProperty:
                    TextProperty.Value = FString.FromString(control.TextInput(TextProperty.Value.ToString(), name));
                    break;

                case StrPropertyData StrProperty:
                    StrProperty.Value = FString.FromString(control.TextInput(StrProperty.Value.ToString(), name));
                    break;

                case BytePropertyData ByteProperty:
                    //bytes are now fucking broken now and always have a value of 0
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
            }
        }

        public void OnValueChanged() => scene.Refresh();

        public void OnValueChangeStart() { }

        public void OnValueSet() { }

        public void UpdateProperties() { }
    }

    //PropertyProvider's function DoUI isn't virtual so I had to rewrite it to rewrite DoUI and link transforms
    class UMapPropertyProvider : IObjectUIContainer
    {
        public UMapPropertyProvider(TransformableObject obj, EditorSceneBase scene, NormalExport export)
        {
            this.export = export;
            this.obj = obj;
            this.scene = scene;
        }

        EditorSceneBase.PropertyCapture? capture = null;

        NormalExport export; TransformableObject obj; EditorSceneBase scene;

        public void OnValueChanged() => scene.Refresh();

        public void DoUI(IObjectUIControl control)
        {
            foreach (var item in export.Data) switch (item.Name.Value.Value)
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
}

