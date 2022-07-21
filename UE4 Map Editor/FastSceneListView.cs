using System;
using System.Windows.Forms;

namespace UE4MapEditor;
//In my editor I don't plan to have multiple-tab editing so this eliminates that
//In this I'm also increasing speed with a library and allowing tree nodes
public partial class FastSceneListView : UserControl
{
    public event EventHandler SelectionChanged;
    //public event ListEventHandler ListExited;
    public event EventHandler ItemClicked;

    public FastSceneListView()
    {
        InitializeComponent();
        SceneObjects.SelectionChanged += (x, y) => SelectionChanged.Invoke(x, y);
        SceneObjects.CellClick += (x, y) => ItemClicked.Invoke(x, y);
    }
}