using GL_EditorFramework.EditorDrawables;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes;

namespace UE4MapEditor;

public partial class Editor : Form
{
    string[] arguments;
    public Editor(string[] args)
    {
        InitializeComponent();
        arguments = args;
    }

    EditorScene scene = new EditorScene();

    //I can't take full credit for this code as a lot is used from the example project on the GL Editor Framework
    void OnLoad(object sender, EventArgs e)
    {
        //Example object adding code
        //for (int i = 0; i < 10; i++) scene.objects.Add(new TransformableObject(new Vector3(i, 0, 0), Vector3.Zero, Vector3.One));
        scene.objects.Add(new Actor(new Vector3(0, 1, 0)));

        //Setup the gl controls
        Display.MainDrawable = scene;
        Display.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(1f);
        Display.CameraDistance = 20;

        //Making this a function doesn't affect performance as the compiler detects and extracts it in compilation
        AddHandlers();

        //Add this to the scene list view
        Objects.RootLists.Add("Test", scene.objects);

        Objects.UpdateComboBoxItems();
        //link the scenes selected objs to sceneListView
        Objects.SelectedItems = scene.SelectedObjects;
        //set current category
        Objects.SetRootList("Test");

        if (arguments.Length > 0) Display.MainDrawable = SpawnActors(GetMapActors(arguments[0]));
    }

    UAsset Map = new();

    void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK) Display.MainDrawable = SpawnActors(GetMapActors(OpenMapDialog.FileName));
    }

    Dictionary<int, int> GetMapActors(string filepath)
    {
        #region set Map value with correct UEVersion
        string ue4version = UEVersion.Text.Replace("4.", "VER_UE4_");
        UE4Version version = UE4Version.UNKNOWN;
        foreach (UE4Version option in ue4version) if (option.ToString() == ue4version) version = option;
        UAsset Map = new UAsset(filepath, version);
        #endregion

        Dictionary<int, int> Actors = new Dictionary<int, int>();
        //There is a negligable difference (less than a nanosecond) in the performance of
        //foreach(NormalExport norm in Map.Exports) and the line below: I just need the export number for the actor index
        for (int exnum = 0; exnum < Map.Exports.Count; exnum++) if (Map.Exports[exnum] is NormalExport norm)
                foreach (PropertyData property in norm.Data)

                    #region find the transform component
                    ;/*if (property.Name == FName.FromString("RootComponent(0)") && property is ObjectPropertyData RootComponent)

                        //find out if the first property of the objectproperty's value is the location of the object
                        if (Map.Exports[int.Parse(RootComponent.Value.ToString())] is NormalExport transform)

                            if (transform.Data[0].Name == FName.FromString("RelativeLocation(0)"))

                                Actors.Add(exnum, int.Parse(RootComponent.Value.ToString()));*/
        #endregion
        return Actors;
    }

    EditorScene SpawnActors(Dictionary<int, int> Actors)
    {
        EditorScene scene = new EditorScene();
        //foreach (var actor in Actors) scene.objects.Add(new Actor());
        return scene;
    }
}