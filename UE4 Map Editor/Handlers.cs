using GL_EditorFramework;
using GL_EditorFramework.EditorDrawables;
using UAssetAPI;

namespace UE4MapEditor;

//Separating handlers to a separate file so my life is easier
partial class Editor
{
    void AddHandlers()
    {
        KeyDown += OnKeyDown;
        scene.SelectionChanged += OnSelectionChanged;
        scene.ObjectsMoved += OnObjectsMoved;
        scene.ListChanged += OnListChanged;
        scene.ListInvalidated += OnListInvalidated;

        Display.KeyDown += OnKeyDown;

        Objects.SelectionChanged += OnObjectSelectionChanged;
        Objects.ListExited += OnObjectListExited;
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

    void OnKeyDown(object? sender, KeyEventArgs KeyPress)
    {
        if (KeyPress.KeyCode == Keys.Delete)
        {
            foreach (Actor item in Objects.SelectedItems) ((NormalExport)Map.Exports[Map.Exports.IndexOf(item.export)]).Data.Clear();
            scene.DeleteSelected();
            Display.Refresh();
            OnSelectionChanged(this, null);
        }

        if (KeyPress.KeyCode == Keys.F) FocusCam(Objects.SelectedItems.ToArray());
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

    void OnObjectListExited(object sender, Framework.ListEventArgs e)
    {
        scene.CurrentList = e.List;
        Display.MainDrawable = scene;
        Objects.UpdateComboBoxItems();
        Objects.SelectedItems = scene.SelectedObjects;
        //fetch available properties for list
        scene.SetupObjectUIControl(Properties);
    }

    void FocusObject(object sender, ItemClickedEventArgs Click)
    {
        if (Click.Clicks == 2 && Click.Item is IEditableObject obj) FocusCam(new[] { obj });
    }
}