using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;

namespace UE4MapEditor;

//Separating handlers to a separate file enhances readablility by reducing arbitrary boilerplate
public partial class Editor
{
    void AddHandlers()
    {
        //MessageBox.Show("don't worry I am actually being called :L");
        scene.SelectionChanged += OnSelectionChanged;
        scene.ObjectsMoved += OnObjectsMoved;
        scene.ListChanged += OnListChanged;
        scene.ListInvalidated += OnListInvalidated;
        Display.KeyDown += OnDisplayKeyDown;

        Objects.SelectionChanged += OnObjectSelectionChanged;
        Objects.ListExited += OnObjectListExited;
        //Objects.ItemsMoved += OnObjectItemsMoved;
    }

    /*private void OnObjectItemsMoved(object sender, ItemsMovedEventArgs e)
    {
        scene.ReorderObjects(Objects.CurrentList, e.OriginalIndex, e.Count, e.Offset);
        e.Handled = true;
        Display.Refresh();
    }*/

    private void OnObjectListExited(object sender, Framework.ListEventArgs e)
    {
        scene.CurrentList = e.List;
        //fetch availible properties for list
        scene.SetupObjectUIControl(Properties);
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

    private void OnListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.Lists.Contains(Objects.CurrentList)) Objects.Refresh();
    }

    private void OnListInvalidated(object sender, Framework.ListEventArgs e)
    {
        if (Objects.CurrentList == e.List) Objects.InvalidateCurrentList();
    }

    private void OnDisplayKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            scene.DeleteSelected();
            Display.Refresh();
            OnSelectionChanged(this, null);
        }
    }

    private void FocusObject(object sender, ItemClickedEventArgs e)
    {
        if (e.Clicks == 2 && e.Item is IEditableObject obj) Display.CameraTarget = obj.GetFocusPoint();
    }
}