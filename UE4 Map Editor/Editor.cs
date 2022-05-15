using DiscordRPC;
using GL_EditorFramework.EditorDrawables;
using GL_EditorFramework.StandardCameras;
using OpenTK;
using UAssetAPI;

namespace UE4MapEditor;

public partial class Editor : Form
{
    static DiscordRpcClient discord = new("975340497071669271");

    public Editor() => InitializeComponent();

    EditorScene scene = new EditorScene();

    void OnLoad(object sender, EventArgs e)
    {
        discord.Initialize();
        discord.SetPresence(new()
        {
            State = "Idle",
            Assets = new() { LargeImageKey = "icon" },
            Timestamps = new() { Start = DateTime.UtcNow },
        });

        //I have to account for UE's scaling so make camera fast
        Display.ActiveCamera = new WalkaroundCamera(500F);
        UEVersion.Text = "Unknown version";

        AddHandlers();

        scene.objects.Add(new ExampleObject(Vector3.Zero));
        LinkScene();

        var arguments = Environment.GetCommandLineArgs();
        if (arguments.Length > 1) ;
    }

    void OnClose(object sender, EventArgs e) => discord.Dispose();

    void LinkScene()
    {
        string file = OpenMapDialog.FileName.Split('\\')[OpenMapDialog.FileName.Split('\\').Length - 1];
        discord.UpdateState("Editing " + file);
        Display.MainDrawable = scene;
        Objects.RootLists.Add(file, scene.objects);
        Objects.UpdateComboBoxItems();
        //link the scene's selected objs to sceneListView
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
}