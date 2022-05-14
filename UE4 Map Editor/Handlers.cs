using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;

namespace UE4MapEditor;

//Separating handlers to a separate file so my life is easier
public partial class Editor
{
    void AddHandlers()
    {
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

    void OnObjectListExited(object sender, Framework.ListEventArgs e)
    {
        scene.CurrentList = e.List;
        //fetch availible properties for list
        scene.SetupObjectUIControl(Properties);
    }

    void OnObjectSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //apply selection changes to scene
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

    void OnSelectionChanged(object? sender, EventArgs? e)
    {
        Objects.Refresh();
        scene.SetupObjectUIControl(Properties);
    }

    void OnObjectsMoved(object? sender, EventArgs e)
    {
        foreach (IObjectUIContainer UIContainer in Properties.ObjectUIContainers) UIContainer.UpdateProperties();
        Properties.Refresh();
    }

    void OnListChanged(object sender, ListChangedEventArgs e)
    {
        if (e.Lists.Contains(Objects.CurrentList)) Objects.Refresh();
    }

    void OnListInvalidated(object sender, Framework.ListEventArgs e)
    {
        if (Objects.CurrentList == e.List) Objects.InvalidateCurrentList();
    }

    void OnDisplayKeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            scene.DeleteSelected();
            Display.Refresh();
            OnSelectionChanged(this, null);
        }
    }

    void FocusObject(object sender, ItemClickedEventArgs e)
    {
        if (e.Clicks == 2 && e.Item is IEditableObject obj) Display.CameraTarget = obj.GetFocusPoint();
    }
}