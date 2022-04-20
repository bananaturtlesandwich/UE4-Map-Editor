using GL_EditorFramework.EditorDrawables;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes;

namespace UE4MapEditor;

public partial class Editor : Form
{
    private string[] arguments;
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
        for (int i = 0; i < 10; i++) scene.objects.Add(new TransformableObject(new Vector3(i, 0, 0), Vector3.Zero, Vector3.One));
        scene.objects.Add(new ActorObject(new Vector3(5, 5, 5)));

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

        if (arguments.Length > 0) MapToScene(arguments[0], UEVersion.Text);
    }


    void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK) MapToScene(OpenMapDialog.FileName, UEVersion.Text);
    }

    static (List<Actor>, UAsset) MapToScene(string filepath, string UEVersion)
    {
        List<Actor> Actors = new List<Actor>();
        UEVersion = UEVersion.Replace("4.", "VER_UE4_");
        UE4Version version = UE4Version.UNKNOWN;
        foreach (UE4Version option in UEVersion) if (option.ToString() == UEVersion) version = option;
        UAsset Map = new UAsset(filepath, version);
        //There is a negligable difference (less than a nanosecond) in the performance of
        //foreach(NormalExport norm in Map.Exports) and the line below
        //I just need the export number for the actor constructor
        for (int exnum = 0; exnum < Map.Exports.Count; exnum++) if(Map.Exports[exnum] is NormalExport norm)
                foreach (PropertyData property in norm.Data)

                    if (property.Name == FName.FromString("RootComponent(0)") && property is ObjectPropertyData RootComponent)

                        //find out if the first property of the objectproperty's value is the location of the object
                        if (Map.Exports[int.Parse(RootComponent.Value.ToString())] is NormalExport transform)

                            if (transform.Data[0].Name == FName.FromString("RelativeLocation(0)"))

                                Actors.Add(new Actor(exnum, int.Parse(RootComponent.Value.ToString()), Map.Exports[exnum].ObjectName.ToString(), Map));
        return (Actors, Map);
    }

    static EditorScene SpawnActors(List<Actor> Actors, UAsset Map)
    {
        EditorScene scene = new EditorScene();
        return scene;
    }
}