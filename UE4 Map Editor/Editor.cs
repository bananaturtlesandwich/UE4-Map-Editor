using GL_EditorFramework.EditorDrawables;
using OpenTK;
using UAssetAPI;
using UAssetAPI.StructTypes;

namespace UE4MapEditor;

public partial class Editor : Form
{
    public Editor() => InitializeComponent();

    EditorScene scene = new EditorScene();

    void OnLoad(object sender, EventArgs e)
    {
        //Example object adding code
        //for (int i = 0; i < 10; i++) scene.objects.Add(new TransformableObject(new Vector3(i, 0, 0), Vector3.Zero, Vector3.One));
        scene.objects.Add(new Actor(new Vector3(0, 0, 0)));

        Display.MainDrawable = scene;
        Display.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(1f);

        AddHandlers();

        Objects.RootLists.Add("Test", scene.objects);

        Objects.UpdateComboBoxItems();
        //link the scenes selected objs to sceneListView
        Objects.SelectedItems = scene.SelectedObjects;
        //set current category
        Objects.SetRootList("Test");

        var arguments = Environment.GetCommandLineArgs();
        if (arguments.Length > 1) Display.MainDrawable = SpawnActors(GetMapActors(arguments[1]));
    }

    Dictionary<int, int> GetMapActors(string filepath)
    {
        UAsset Map = new UAsset(filepath, versions[Array.IndexOf(versionstrings, UEVersion.Text)]);

        Dictionary<int, int> Actors = new Dictionary<int, int>();
        Export[] TransformComponents = Map.Exports.Where(ex => ((NormalExport)ex).Data[0].Name == FName.FromString("RelativeLocation")).ToArray();
        foreach (var TransformComponent in TransformComponents) scene.objects.Add(new Actor(ToVector3((VectorPropertyData)(TransformComponent as NormalExport).Data[0])));
        return Actors;
    }

    EditorScene SpawnActors(Dictionary<int, int> Actors)
    {
        EditorScene scene = new EditorScene();
        //foreach (var actor in Actors) scene.objects.Add(new Actor());
        return scene;
    }

    void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK) Display.MainDrawable = SpawnActors(GetMapActors(OpenMapDialog.FileName));
    }

    readonly string[] versionstrings = new string[]
    {
        "Unknown version",
        "4.0",
        "4.1",
        "4.2",
        "4.3",
        "4.4",
        "4.5",
        "4.6",
        "4.7",
        "4.8",
        "4.9",
        "4.10",
        "4.11",
        "4.12",
        "4.13",
        "4.14",
        "4.15",
        "4.16",
        "4.17",
        "4.18",
        "4.19",
        "4.20",
        "4.21",
        "4.22",
        "4.23",
        "4.24",
        "4.25",
        "4.26",
        "4.27"
    };

    readonly UE4Version[] versions =
    {
        UE4Version.UNKNOWN,
        UE4Version.VER_UE4_0,
        UE4Version.VER_UE4_1,
        UE4Version.VER_UE4_2,
        UE4Version.VER_UE4_3,
        UE4Version.VER_UE4_4,
        UE4Version.VER_UE4_5,
        UE4Version.VER_UE4_6,
        UE4Version.VER_UE4_7,
        UE4Version.VER_UE4_8,
        UE4Version.VER_UE4_9,
        UE4Version.VER_UE4_10,
        UE4Version.VER_UE4_11,
        UE4Version.VER_UE4_12,
        UE4Version.VER_UE4_13,
        UE4Version.VER_UE4_14,
        UE4Version.VER_UE4_15,
        UE4Version.VER_UE4_16,
        UE4Version.VER_UE4_17,
        UE4Version.VER_UE4_18,
        UE4Version.VER_UE4_19,
        UE4Version.VER_UE4_20,
        UE4Version.VER_UE4_21,
        UE4Version.VER_UE4_22,
        UE4Version.VER_UE4_23,
        UE4Version.VER_UE4_24,
        UE4Version.VER_UE4_25,
        UE4Version.VER_UE4_26,
        UE4Version.VER_UE4_27,
    };

    Vector3 ToVector3(VectorPropertyData Vector) =>
        new Vector3(Vector.Value.X, Vector.Value.Y, Vector.Value.Z);

    VectorPropertyData ToVectorPropertyData(Vector3 Vector) =>
        new VectorPropertyData(FName.FromString("RelativeLocation")) { Value = new(Vector.X, Vector.Y, Vector.Z) };
}