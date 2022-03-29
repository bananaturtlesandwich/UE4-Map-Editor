using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using OpenTK;

namespace UE4MapEditor
{
    public partial class Editor : Form
    {
        public Editor() { InitializeComponent(); }

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

            //Add event handlers
            scene.SelectionChanged += OnSelectionChanged;
            scene.ObjectsMoved += OnObjectsMoved;
            scene.ListChanged += OnListChanged;
            scene.ListInvalidated += OnListInvalidated;
            Display.KeyDown += OnDisplayKeyDown;

            Objects.SelectionChanged += OnObjectSelectionChanged;
            Objects.ItemsMoved += OnObjectItemsMoved;
            Objects.ListExited += OnObjectListExited;

            //Add this to the scene list view
            Objects.RootLists.Add("Test", scene.objects);

            Objects.UpdateComboBoxItems();
            //link the scenes selected objs to sceneListView
            Objects.SelectedItems = scene.SelectedObjects;
            //set current category (highly recommended to do once all categories are added)
            Objects.SetRootList("Test");
        }

        private void OnObjectListExited(object sender, Framework.ListEventArgs e)
        {
            scene.CurrentList = e.List;
            //fetch availible properties for list
            scene.SetupObjectUIControl(Properties);
        }

        private void OnObjectItemsMoved(object sender, ItemsMovedEventArgs e)
        {
            scene.ReorderObjects(Objects.CurrentList, e.OriginalIndex, e.Count, e.Offset);
            e.Handled = true;
            Display.Refresh();
        }

        private void OnObjectSelectionChanged(object sender, SelectionChangedEventArgs e)
        {//apply selection changes to scene
            if (e.SelectionChangeMode == SelectionChangeMode.SET)
            {
                scene.SelectedObjects.Clear();
                foreach (ISelectable obj in e.Items) obj.SelectDefault(Display);
            }
            else if (e.SelectionChangeMode == SelectionChangeMode.ADD)
                foreach (ISelectable obj in e.Items) obj.SelectDefault(Display);
            else
                foreach (ISelectable obj in e.Items) obj.DeselectAll(Display);

            e.Handled = true;
            Display.Refresh();

            OnSelectionChanged(this, null);
        }

        private void OnSelectionChanged(object? sender, EventArgs? e)
        {
            Objects.Refresh();
            scene.SetupObjectUIControl(Properties);
        }

        private void OnObjectsMoved(object? sender, EventArgs e)
        {
            foreach (IObjectUIContainer UIContainer in Properties.ObjectUIContainers) UIContainer.UpdateProperties();
            Properties.Refresh();
        }

        private void OnListChanged(object sender, ListChangedEventArgs e) { if (e.Lists.Contains(Objects.CurrentList)) Objects.Refresh(); }

        private void OnListInvalidated(object sender, Framework.ListEventArgs e) { if (Objects.CurrentList == e.List) Objects.InvalidateCurrentList(); }

        private void OnDisplayKeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                scene.DeleteSelected();
                Display.Refresh();
                OnSelectionChanged(this, null);
            }
        }

        private void FocusObject(object sender, ItemClickedEventArgs e) { if (e.Clicks == 2 && e.Item is IEditableObject obj) Display.CameraTarget = obj.GetFocusPoint(); }

        private void OpenMap(object sender, EventArgs e)
        {
            if (OpenMapDialog.ShowDialog()==DialogResult.OK)
            {

            }
        }
    }
}