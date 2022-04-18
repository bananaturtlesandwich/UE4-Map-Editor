using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor;

public partial class Editor : Form
{
    private string[] arguments;
    public Editor(string[] args)
    {
        InitializeComponent();
        arguments = args;
    }

    private EditorScene scene = new EditorScene();

    //I can't take full credit for this code as a lot is used from the example project on the GL Editor Framework
    private void OnLoad(object sender, EventArgs e)
    {
        //Example object adding code
        EditableObject obj;
        for (int i = 5; i < 10; i++) scene.objects.Add(obj = new TransformableObject(new Vector3(i, 0, 0), Vector3.Zero, Vector3.One));

        //Setup the gl controls
        Display.MainDrawable = scene;
        Display.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(1f);
        Display.CameraDistance = 20;

        //Making this a funcion doesn't affect performance as the compiler already detects this
        AddHandlers();

        //Add this to the scene list view
        Objects.RootLists.Add("Test", scene.objects);

        Objects.UpdateComboBoxItems();
        //link the scenes selected objs to sceneListView
        Objects.SelectedItems = scene.SelectedObjects;
        //set current category (highly recommended to do once all categories are added)
        Objects.SetRootList("Test");
    }


    private void OpenMap(object sender, EventArgs e)
    {
        if (OpenMapDialog.ShowDialog() == DialogResult.OK)
        {

        }
    }
}