using GL_EditorFramework.EditorDrawables;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace UE4MapEditor;

public partial class Editor : Form
{
    public Editor() => InitializeComponent();

    EditorScene scene = new EditorScene();

    void OnLoad(object sender, EventArgs e)
    {
        //I have to account for UE's scaling
        Display.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(500f);
        UEVersion.Text = "Unknown version";

        AddHandlers();

        var arguments = Environment.GetCommandLineArgs();
        if (arguments.Length > 1) Display.MainDrawable = GetMapActors(arguments[1]);
    }

    EditorScene GetMapActors(string filepath)
    {
        UAsset Map = new UAsset(@filepath, versions[Array.IndexOf(versionstrings, UEVersion.Text)]);

        List<(int, int)> Actors = new();
        List<int> Transforms = new();
        //First scan for transforms
        for (int i = 0; i < Map.Exports.Count; i++)
            if (((NormalExport)Map.Exports[i]).Data.Count > 0)
                if (((NormalExport)Map.Exports[i]).Data[0].Name == FName.FromString("RelativeLocation"))
                    Transforms.Add(i);
        //second scan for actors with refs to those transforms
        for (int i = 0; i < Map.Exports.Count; i++)
            foreach (PropertyData prop in ((NormalExport)Map.Exports[i]).Data)
                if (prop is ObjectPropertyData obj && Transforms.Contains(obj.Value.Index))
                    Actors.Add((i, obj.Value.Index));
        EditorScene scene = new EditorScene();
        //Again to account for UE4's scaling I divide the vector by 100 (kinda like you do when importing to blender)
        foreach (var actor in Actors)
            scene.objects.Add(new NamedTransformableObject(Map.Exports[actor.Item1].ObjectName.ToString(), ToVector3((VectorPropertyData)((StructPropertyData)((NormalExport)Map.Exports[actor.Item2]).Data[0]).Value[0]) / 100, Vector3.Zero, Vector3.One));
        return scene;
    }

    void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK) scene = GetMapActors(OpenMapDialog.FileName);
        string file = OpenMapDialog.FileName.Split('\\')[OpenMapDialog.FileName.Split('\\').Length - 1];
        Display.MainDrawable = scene;
        Objects.RootLists.Add(file, scene.objects);
        Objects.UpdateComboBoxItems();
        //link the scenes selected objs to sceneListView
        Objects.SelectedItems = scene.SelectedObjects;
        //set current category
        Objects.SetRootList(file);
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