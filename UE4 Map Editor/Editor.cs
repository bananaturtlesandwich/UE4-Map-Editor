using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static GL_EditorFramework.Framework;

namespace UE4_Map_Editor
{
    public partial class Editor : Form
    {
        public Editor() => InitializeComponent();

        //private TestProvider propertyContainer = new TestProvider();

        private EditorScene scene;

        private PropertyChanges propertyChangesAction = new PropertyChanges();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            EditableObject obj;

            #region Example object adding code for noobs like me
            scene = new EditorScene();

            //scene.objects.Add(obj = new ExampleObject(new Vector3(0, -4, 0)));

            /*List<PathPoint> pathPoints = new List<PathPoint>
            {
                new PathPoint(
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 0),
                new Vector3(2, 0, 0)
                ),
                new PathPoint(
                new Vector3(8, 4, 2),
                new Vector3(-4, 0, 4),
                new Vector3(4, 0, -4)
                ),
                new PathPoint(
                new Vector3(4, 2, -6),
                new Vector3(0, 0, 0),
                new Vector3(0, 0, 0)
                )
            };*/

            //scene.objects.Add(obj = new Path(pathPoints));

            /*for (int i = 0; i < 20; i++)
            {
                pathPoints = new List<PathPoint>
                {
                new PathPoint(
                new Vector3(-3, 6+i*2, 0),
                new Vector3(0, 0, -1.75f),
                new Vector3(0, 0, 1.75f)
                ),
                new PathPoint(
                new Vector3(0, 6+i*2, 3),
                new Vector3(-1.75f, 0, 0),
                new Vector3(1.75f, 0, 0)
                ),
                new PathPoint(
                new Vector3(3, 6+i*2, 0),
                new Vector3(0, 0, 1.75f),
                new Vector3(0, 0, -1.75f)
                ),
                new PathPoint(
                new Vector3(0, 6+i*2, -3),
                new Vector3(1.75f, 0, 0),
                new Vector3(-1.75f, 0, 0)
                )};

                //scene.objects.Add(obj = new Path(pathPoints) { Closed = true });
            }*/

            for (int i = 5; i < 10; i++) scene.objects.Add(obj = new TransformableObject(new Vector3(i, 0, 0), Vector3.Zero, Vector3.One));
            #endregion

            //setup the gl controls
            Display.MainDrawable = scene;

            Display.ActiveCamera = new GL_EditorFramework.StandardCameras.InspectCamera(1f);
            Display.CameraDistance = 20;

            //add event handlers to scene and gl control
            scene.SelectionChanged += Scene_SelectionChanged;
            scene.ObjectsMoved += Scene_ObjectsMoved;
            scene.ListChanged += Scene_ListChanged;
            scene.ListEntered += Scene_ListEntered;
            scene.ListInvalidated += MapObjectsInvalidated;
            Display.KeyDown += Display_KeyDown;

            //add categories to sceneListView (in this case 15 references to the same list, 
            //which should never be done and only serves for demonstration purposes)
            for (int i = 0; i < 15; i++)
                MapObjects.RootLists.Add("Test" + i, scene.objects);

            MapObjects.UpdateComboBoxItems();

            //link the scenes selected objs to sceneListView
            MapObjects.SelectedItems = scene.SelectedObjects;
            //set current category (highly recommended to do once all categories are added)
            MapObjects.SetRootList("Test");

            //add event handlers to sceneListView
            MapObjects.SelectionChanged += SceneListView_SelectionChanged;
            MapObjects.ItemsMoved += SceneListView_ItemsMoved;
            MapObjects.ListExited += SceneListView_ListExited;
        }

        private void MapObjectsInvalidated(object sender, ListEventArgs e)
        {
            if (MapObjects.CurrentList == e.List) MapObjects.InvalidateCurrentList();
        }

        private void SceneListView_ListExited(object sender, ListEventArgs e)
        {
            scene.CurrentList = e.List;
            //fetch availible properties for list
            scene.SetupObjectUIControl(Properties);
        }

        private void Scene_ListEntered(object sender, ListEventArgs e)
        {
            MapObjects.EnterList(e.List);
            if (e.List as List<PathPoint> != null)
                btnAdd.Text = "Add Point";
            else
                btnAdd.Text = "Add Object";
        }

        private void SceneListView_ItemsMoved(object sender, ItemsMovedEventArgs e)
        {
            scene.ReorderObjects(MapObjects.CurrentList, e.OriginalIndex, e.Count, e.Offset);
            e.Handled = true;
            Display.Refresh();
        }

        private void Scene_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.Lists.Contains(MapObjects.CurrentList))
            {
                //MapObjects.UpdateAutoScrollHeight();
                MapObjects.Refresh();
            }
        }

        private void SceneListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //apply selection changes to scene
            if (e.SelectionChangeMode == SelectionChangeMode.SET)
            {
                scene.SelectedObjects.Clear();

                foreach (ISelectable obj in e.Items)
                    obj.SelectDefault(Display);
            }
            else if (e.SelectionChangeMode == SelectionChangeMode.ADD)
            {
                foreach (ISelectable obj in e.Items)
                    obj.SelectDefault(Display);
            }
            else //SelectionChangeMode.SUBTRACT
            {
                foreach (ISelectable obj in e.Items)
                    obj.DeselectAll(Display);
            }

            e.Handled = true;
            Display.Refresh();

            Scene_SelectionChanged(this, null);
        }

        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //delete all selected objects if possible
                //the deletion is handled by the scene and it's objects
                scene.DeleteSelected();
                Display.Refresh();
                //MapObjects.UpdateAutoScrollHeight();
                Scene_SelectionChanged(this, null);
            }
        }

        private void Scene_ObjectsMoved(object sender, EventArgs e)
        {
            //update the property control because properties might have changed
            foreach (IObjectUIContainer objectUIContainer in Properties.ObjectUIContainers)
                objectUIContainer.UpdateProperties();

            Properties.Refresh();
        }

        private void Scene_SelectionChanged(object sender, EventArgs e)
        {
            //update sceneListView
            MapObjects.Refresh();

            //fetch availible properties for selection
            scene.SetupObjectUIControl(Properties);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (scene.CurrentList is List<PathPoint> points)
            {
                //add new pathpoint to path

                PathPoint point;

                if (points.Count > 0)
                    scene.Add(scene.CurrentList, point = new PathPoint(points.Last().Position, Vector3.Zero, Vector3.Zero));
                else
                    scene.Add(scene.CurrentList, point = new PathPoint(Vector3.Zero, Vector3.Zero, Vector3.Zero));
            }
            else
                //add new TransformableObject to the scene
                scene.Add(scene.CurrentList, new TransformableObject(Vector3.Zero, Vector3.Zero, Vector3.One));


            //MapObjects.UpdateAutoScrollHeight();
        }

        private void SceneListView_ItemDoubleClicked(object sender, ItemClickedEventArgs e)
        {
            if (e.Clicks == 2 && e.Item is IEditableObject obj)
                Display.CameraTarget = obj.GetFocusPoint();
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scene.Hovered?.Visible == true)
            {
                scene.Hovered.Visible = false;
                Display.Repick();
                Display.Refresh();
            }
        }

        private void ShowAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var obj in scene.EditableObjects)
                obj.Visible = true;

            Display.Repick();
            Display.Refresh();
        }

        private void OpenMapUmap_Click(object sender, EventArgs e)
        {
            if (umapDialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
    /*
    public class TestProvider : IPropertyProvider
    {
        public Vector3 pCenter;
        public Vector3 center;

        bool showMore = false;

        public Path selectedPath;
        public event EventHandler PathPointEdit;

        public void Setup(IEnumerable<object> editableObjects)
        {
            if (editableObjects.Count() == 1)
                selectedPath = (editableObjects.First() as Path);
            else
                selectedPath = null;

            EditableObject.BoundingBox box = EditableObject.BoundingBox.Default;
            foreach (IEditableObject obj in editableObjects)
            {
                obj.GetSelectionBox(ref box);
            }
            center = box.GetCenter();
            pCenter = center;
        }

        public void DoUI(IObjectPropertyControl control)
        {
            center.X = control.NumberInput(center.X, "Position X", 0.125f, 2);
            center.Y = control.NumberInput(center.Y, "Position Y", 0.125f, 2);
            center.Z = control.NumberInput(center.Z, "Position Z", 0.125f, 2);

            if(WinInput.Keyboard.IsKeyDown(WinInput.Key.LeftShift))
                center = control.Vector3Input(center, "Position");
            else
                center = control.Vector3Input(center, "Position", 0.125f, 2);

            
            if (showMore)
            {
                if (control.Button("Hide Links"))
                    showMore = false;

                if (control.Link("Link 1"))
                    MessageBox.Show("Thx for clicking.");
                if (control.Link("Link 2"))
                    MessageBox.Show("Thx for clicking.");
                if (control.Link("Link 3"))
                    MessageBox.Show("Thx for clicking.");
            }
            else
            {
                if (control.Button("Show Links"))
                    showMore = true;
            }

            if (selectedPath != null)
            {
                if (control.Button("Edit PathPoints"))
                    PathPointEdit?.Invoke(this, null);
            }
        }
    }
    */
}
