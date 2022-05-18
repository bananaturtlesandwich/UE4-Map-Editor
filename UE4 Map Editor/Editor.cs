using DiscordRPC;
using GL_EditorFramework.EditorDrawables;
using GL_EditorFramework.StandardCameras;
using OpenTK;
using UAssetAPI;
using UAssetAPI.PropertyTypes;
using UAssetAPI.StructTypes;

namespace UE4MapEditor;

public partial class Editor : Form
{
    static DiscordRpcClient discord = new("975340497071669271");

    public Editor() => InitializeComponent();

    readonly string configfile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                                 System.IO.Path.DirectorySeparatorChar
                                 + "UE4MapEditor" +
                                 System.IO.Path.DirectorySeparatorChar +
                                 "config.txt";

    EditorScene scene = new EditorScene();

    UAsset Map = new();

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
        Display.ActiveCamera = new WalkaroundCamera(1F);
        UEVersion.Text = "Unknown version";
        if (File.Exists(configfile)) UEVersion.Text = File.ReadAllText(configfile);

        AddHandlers();

        var arguments = Environment.GetCommandLineArgs();
        if (arguments.Length > 1) ParseMap(arguments[1]);
    }

    void OnClose(object sender, EventArgs e)
    {
        Directory.CreateDirectory(configfile.Replace(System.IO.Path.DirectorySeparatorChar + "config.txt", ""));
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
        Map = new UAsset(@filepath, versions[Array.IndexOf(versionstrings, UEVersion.Text)]);
        if (!Map.VerifyBinaryEquality())
        {
            MessageBox.Show("Map will not maintain binary equality. Please create a github issue on the main UAssetAPI repository");
            return;
        }
        foreach (var export in Map.Exports)
        {
            if (export is FunctionExport || export is RawExport) continue;
            if (export is NormalExport norm)
                foreach (var property in norm.Data) if (property.Name.Value.Value == "RelativeLocation" || property.Name.Value.Value == "RelativeRotation" || property.Name.Value.Value == "RelativeScale3D")
                        scene.objects.Add(new Actor(norm));
        }
        //remove duplicates
        for (int i = 0; i < scene.objects.Count; i++)
            for (int j = 0; j < scene.objects.Count; j++)
                if (scene.objects[i] == scene.objects[j])
                    scene.objects.RemoveAt(i);
        LinkScene();
    }

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
        FocusCam(scene.objects.ToArray());
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

    void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK) ParseMap(OpenMapDialog.FileName);
    }

    void SaveMap(object sender, EventArgs e) => Map.Write(Map.FilePath);

    void SaveMapAs(object sender, EventArgs e)
    {
        if (SaveMapDialog.ShowDialog() == DialogResult.OK) Map.Write(SaveMapDialog.FileName);
    }

    void FocusCam(object[] targets)
    {
        if (Objects.SelectedItems.Count == 1)
        {
            Display.CameraTarget = ((TransformableObject)Objects.SelectedItems.ToArray()[0]).GetFocusPoint();
            Display.CameraDistance = 20F;
            return;
        }
        if (Objects.SelectedItems.Count > 0)
        {
            Vector3[] positions = new Vector3[targets.Length];
            Vector3 target = ((IEditableObject)targets[0]).GetFocusPoint();
            positions[0] = ((TransformableObject)targets[0]).Position;
            for (int i = 1; i < Objects.SelectedItems.Count; i++)
            {
                target = Vector3.Lerp(target, ((IEditableObject)targets[i]).GetFocusPoint(), 0.5f);
                positions[i] = ((TransformableObject)targets[i]).Position;
            }
            Vector3 max = positions[0];
            Vector3 min = max;
            for (int i = 1; i < positions.Length; i++)
            {
                if (max.X < positions[i].X) max.X = positions[i].X;
                if (max.Y < positions[i].Y) max.Y = positions[i].Y;
                if (max.Z < positions[i].Z) max.Z = positions[i].Z;
                if (min.X > positions[i].X) min.X = positions[i].X;
                if (min.Y > positions[i].Y) min.Y = positions[i].Y;
                if (min.Z > positions[i].Z) min.Z = positions[i].Z;
            }
            Display.CameraTarget = target;
            Display.CameraDistance = Vector3.Distance(max, min);
        }
    }
}