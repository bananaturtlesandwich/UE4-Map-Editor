using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor
{
    public partial class Editor : Form
    {
        public Editor() => InitializeComponent();

        private EditorScene scene = new EditorScene();

        //I can't take full credit for this code as a lot is used from the example project on the GL Editor Framework
        private void OnLoad(object sender, EventArgs e)
        {
            //base.OnLoad(e);

            #region Example object adding code
            for (int i = 5; i < 10; i++) scene.objects.Add(new TransformableObject(new Vector3(i, 0, 0), Vector3.Zero, Vector3.One));

            //Setup the gl controls
            Display.MainDrawable = scene;
            Display.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(1f);
            Display.CameraDistance = 20;

            //Add event handlers

            //Add this to the scene list view
            Objects.RootLists.Add("Test", scene.objects);
            //link the scenes selected objs to sceneListView
            Objects.SelectedItems = scene.SelectedObjects;
            //set current category (highly recommended to do once all categories are added)
            Objects.SetRootList("Test");
            #endregion
        }
    }
}