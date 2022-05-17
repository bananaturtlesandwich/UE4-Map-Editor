using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes;

namespace UE4MapEditor;

public class Actor : TransformableObject
{
    public Actor(NormalExport export, Vector3 pos, Vector3 rot, Vector3 scale) : base(pos, rot, scale)
    {
        this.export = export;
        name = export.ObjectName.ToString().Replace("(0)","");
    }

    public NormalExport export;

    string name = "";

    public override string ToString() => name;

    public override bool TrySetupObjectUIControl(EditorSceneBase scene, ObjectUIControl objectUIControl)
    {
        if (!Selected) return false;
        objectUIControl.AddObjectUIContainer(new PropertyProvider(this, scene), "Transform");
        objectUIControl.AddObjectUIContainer(new ActorUIControl(this, scene,export), "Properties");
        return true;
    }

    class ActorUIControl : IObjectUIContainer
    {
        SingleObject obj;
        EditorSceneBase scene;
        NormalExport export;

        public ActorUIControl(SingleObject obj,EditorSceneBase scene,NormalExport export)
        {
            this.obj= obj;
            this.scene = scene;
            this.export = export;
        }
        public void DoUI(IObjectUIControl control)
        {
            foreach(var data in export.Data)
            {
                string name = data.Name.ToString().Replace("(0)","");
                if (data is BoolPropertyData BoolProperty) 
                { 
                    BoolProperty.Value = control.CheckBox(name, BoolProperty.Value); 
                    continue; 
                }
                #region string inputs
                if (data is EnumPropertyData EnumProperty)
                {
                    EnumProperty.Value = FName.FromString(control.TextInput(EnumProperty.Value.ToString(), name));
                    continue;
                }
                if(data is NamePropertyData NameProperty)
                {
                    NameProperty.Value = FName.FromString(control.TextInput(NameProperty.Value.ToString(), name));
                    continue;
                }
                if (data is TextPropertyData TextProperty)
                {
                    TextProperty.Value = FString.FromString(control.TextInput(TextProperty.Value.ToString(), name));
                    continue;
                }
                if(data is StrPropertyData StrProperty)
                {
                    StrProperty.Value = FString.FromString(control.TextInput(StrProperty.Value.ToString(), name));
                    continue;
                }
                if(data is BytePropertyData ByteProperty)
                {
                    ByteProperty.Value = export.Asset.AddNameReference(FString.FromString(control.TextInput(export.Asset.GetNameReference(ByteProperty.Value).ToString(), name)));
                    continue;
                }
                if(data is SoftObjectPropertyData SoftObjectProperty)
                {
                    SoftObjectProperty.Value = FName.FromString(control.TextInput(SoftObjectProperty.Value.ToString(), name));
                    continue;
                }
                if(data is AssetObjectPropertyData AssetObjectProperty)
                {
                    AssetObjectProperty.Value = FString.FromString(control.TextInput(AssetObjectProperty.Value.ToString(),name));
                    continue;
                }
                #endregion

                #region number inputs
                if (data is ObjectPropertyData ObjectProperty)
                {
                    ObjectProperty.Value.Index = (int)control.NumberInput(ObjectProperty.Value.Index, name);
                    continue;
                }
                if (data is Int8PropertyData Int8Property)
                {
                    Int8Property.Value = (sbyte)control.NumberInput(Int8Property.Value,name);
                    continue;
                }
                if (data is Int16PropertyData Int16Property)
                {
                    Int16Property.Value = (short)control.NumberInput(Int16Property.Value, name);
                    continue;
                }
                if (data is IntPropertyData IntProperty)
                {
                    IntProperty.Value = (int)control.NumberInput(IntProperty.Value, name);
                    continue;
                }
                if (data is Int64PropertyData Int64Property)
                {
                    Int64Property.Value = (long)control.NumberInput(Int64Property.Value, name);
                    continue;
                }
                if (data is UInt16PropertyData UInt16Property)
                {
                    UInt16Property.Value = (ushort)control.NumberInput(UInt16Property.Value, name);
                    continue;
                }
                if (data is UInt32PropertyData UInt32Property)
                {
                    UInt32Property.Value = (uint)control.NumberInput(UInt32Property.Value, name);
                    continue;
                }
                if (data is UInt64PropertyData UInt64Property)
                {
                    UInt64Property.Value = (ulong)control.NumberInput(UInt64Property.Value, name);
                    continue;
                }
                if(data is FloatPropertyData FloatProperty)
                {
                    FloatProperty.Value=control.NumberInput(FloatProperty.Value, name);
                    continue;
                }
                if(data is DoublePropertyData DoubleProperty)
                {
                    DoubleProperty.Value=control.NumberInput((float)DoubleProperty.Value,name);
                    continue;
                }
                #endregion
            }
        }

        public void OnValueChanged() => scene.Refresh();

        public void OnValueChangeStart() { }

        public void OnValueSet() { }

        public void UpdateProperties() { }
    }
}

