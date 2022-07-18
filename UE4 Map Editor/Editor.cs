using DiscordRPC;
using GL_EditorFramework.EditorDrawables;
using GL_EditorFramework.StandardCameras;
using OpenTK;
using UAssetAPI;
using UAssetAPI.UnrealTypes;

namespace UE4MapEditor;

public partial class Editor : Form
{
    static DiscordRpcClient discord = new("975340497071669271");

    public Editor() => InitializeComponent();

    //no need to use Path.DirectorySeparatorChar because this is winforms and there's a name clash anyway
    readonly string configfile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\UE4MapEditor\config.txt";

    EditorScene scene = new EditorScene();

    UAsset Map = new();

    void OnLoad(object sender, EventArgs e)
    {
        GizmoRenderer.Initialise();

        discord.Initialize();
        discord.SetPresence(new()
        {
            State = "Idle",
            Assets = new() { LargeImageKey = "icon" },
            Timestamps = new() { Start = DateTime.UtcNow },
        });

        //I have to account for UE's scaling so make camera fast
        Display.ActiveCamera = new WalkaroundCamera(100f);
        UEVersion.Text = File.Exists(configfile) ? File.ReadAllText(configfile) : "Unknown version";

        AddHandlers();

        //allow file association with the application
        var arguments = Environment.GetCommandLineArgs();
        if (arguments.Length > 1) ParseMap(arguments[1]);
    }

    void OnClose(object sender, EventArgs e)
    {
        Directory.CreateDirectory(configfile[..^10]);
        File.WriteAllText(configfile, UEVersion.Text);
        discord.Dispose();
    }

    void ParseMap(string filepath)
    {
        scene.objects.Clear();
        if (UEVersion.Text == "Unknown version")
        {
            MessageBox.Show("Please set a UE version for the map");
            return;
        }
        Map = new UAsset(@filepath, Version[UEVersion.Text]);
        if (!Map.VerifyBinaryEquality())
        {
            MessageBox.Show("Map will not maintain binary equality. Please create a github issue on the main UAssetAPI repository");
            return;
        }
        foreach (var export in FindActors()) scene.objects.Add(new Actor(export));
        LinkScene();
    }

    //I definitely need to find a more reliable way of finding actors
    //atm it definitely misses a lot of things by relying on outer index
    //also if an actor has default values for all transforms it won't be detected
    List<NormalExport> FindActors()
    {
        List<NormalExport> actors = new();
        for (int i = 0; i < Map.Exports.Count; i++)
            if (Map.Exports[i] is NormalExport export)
                foreach (var property in export.Data) if (property.Name.Value.Value == "RelativeLocation" || property.Name.Value.Value == "RelativeRotation" || property.Name.Value.Value == "RelativeScale3D")
                    {
                        actors.Add(export);
                        break;
                    }
        return actors;
    }

    void LinkScene()
    {
        //not sure if I want to support tabs for editing multiple maps at a time-not sure if there's a point
        Objects.RootLists.Clear();
        string file = OpenMapDialog.FileName.Split('\\')[^1];
        discord.UpdateState("Editing " + file);
        Display.MainDrawable = scene;
        Objects.RootLists.Add(file, scene.objects);
        Objects.UpdateComboBoxItems();
        //link the scene's selected objects to sceneListView
        Objects.SelectedItems = scene.SelectedObjects;
        //set current category
        Objects.SetRootList(file);
        FocusCam(scene.objects.ToArray());
    }

    void FocusCam(object[] targets)
    {
        if (Objects.SelectedItems.Count == 0) return;

        if (Objects.SelectedItems.Count == 1)
        {
            Display.CameraTarget = ((IEditableObject)targets[0]).GetFocusPoint();
            //Display.CameraDistance = 10f;
            return;
        }
        Vector3 target = ((IEditableObject)targets[0]).GetFocusPoint();

        Vector3 min, max;
        min = max = ((SingleObject)targets[0]).Position;
        for (int i = 1; i < target.Length; i++)
        {
            target = Vector3.Lerp(target, ((IEditableObject)targets[i]).GetFocusPoint(), 0.5f);
            var pos = ((SingleObject)targets[i]).Position;
            if (max.X < pos.X) max.X = pos.X;
            if (max.Y < pos.Y) max.Y = pos.Y;
            if (max.Z < pos.Z) max.Z = pos.Z;
            if (min.X > pos.X) min.X = pos.X;
            if (min.Y > pos.Y) min.Y = pos.Y;
            if (min.Z > pos.Z) min.Z = pos.Z;
        }
        Display.CameraTarget = target;
        Display.CameraDistance = Vector3.Distance(max, min);
    }

    void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK) ParseMap(OpenMapDialog.FileName);
    }

    void SaveMap(object sender, EventArgs e) => Map.Write(Map.FilePath);

    void SaveMapAs(object sender, EventArgs e)
    {
        if (SaveMapDialog.ShowDialog() == DialogResult.OK) Map.Write(SaveMapDialog.FileName);
    }

    void OnAddClicked(object sender, EventArgs e)
    {
        if (AddObjectDialog.ShowDialog() == DialogResult.OK)
        {
            if (UEVersion.Text == "Unknown Version")
            {
                MessageBox.Show("Please set a UE version for the map");
                return;
            }
            UAsset NewMap = new(AddObjectDialog.FileName, Version[UEVersion.Text]);
            if (!NewMap.VerifyBinaryEquality())
            {
                MessageBox.Show("Map will not maintain binary equality. Please create a github issue on the main UAssetAPI repository");
                return;
            }
            new ObjectSelector(FindActors()).ShowDialog();
        }
    }

    readonly Dictionary<string, UE4Version> Version = new()
    {
        { "Unknown version", UE4Version.UNKNOWN },
        { "4.0", UE4Version.VER_UE4_0 },
        { "4.1", UE4Version.VER_UE4_1 },
        { "4.2", UE4Version.VER_UE4_2 },
        { "4.3", UE4Version.VER_UE4_3 },
        { "4.4", UE4Version.VER_UE4_4 },
        { "4.5", UE4Version.VER_UE4_5 },
        { "4.6", UE4Version.VER_UE4_6 },
        { "4.7", UE4Version.VER_UE4_7 },
        { "4.8", UE4Version.VER_UE4_8 },
        { "4.9", UE4Version.VER_UE4_9 },
        { "4.10", UE4Version.VER_UE4_10 },
        { "4.11", UE4Version.VER_UE4_11 },
        { "4.12", UE4Version.VER_UE4_12 },
        { "4.13", UE4Version.VER_UE4_13 },
        { "4.14", UE4Version.VER_UE4_14 },
        { "4.15", UE4Version.VER_UE4_15 },
        { "4.16", UE4Version.VER_UE4_16 },
        { "4.17", UE4Version.VER_UE4_17 },
        { "4.18", UE4Version.VER_UE4_18 },
        { "4.19", UE4Version.VER_UE4_19 },
        { "4.20", UE4Version.VER_UE4_20 },
        { "4.21", UE4Version.VER_UE4_21 },
        { "4.22", UE4Version.VER_UE4_22 },
        { "4.23", UE4Version.VER_UE4_23 },
        { "4.24", UE4Version.VER_UE4_24 },
        { "4.25", UE4Version.VER_UE4_25 },
        { "4.26", UE4Version.VER_UE4_26 },
        { "4.27", UE4Version.VER_UE4_27 }
    };
}