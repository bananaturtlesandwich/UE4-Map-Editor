using GL_EditorFramework.GL_Core;
using GL_EditorFramework;

namespace UE4MapEditor;

partial class Editor
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Add = new System.Windows.Forms.ToolStripMenuItem();
            this.UEVersion = new System.Windows.Forms.ToolStripComboBox();
            this.Split = new System.Windows.Forms.SplitContainer();
            this.Sidebar = new System.Windows.Forms.SplitContainer();
            this.Objects = new GL_EditorFramework.SceneListView();
            this.PropertyList = new GL_EditorFramework.ObjectUIControl();
            this.Display = new GL_EditorFramework.GL_Core.GL_ControlModern();
            this.OpenMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar)).BeginInit();
            this.Sidebar.Panel1.SuspendLayout();
            this.Sidebar.Panel2.SuspendLayout();
            this.Sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStrip,
            this.EditToolStrip,
            this.UEVersion});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1258, 37);
            this.MenuStrip.TabIndex = 0;
            // 
            // FileToolStrip
            // 
            this.FileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.SaveAs});
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.Size = new System.Drawing.Size(54, 33);
            this.FileToolStrip.Text = "File";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open.Size = new System.Drawing.Size(285, 34);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.OpenMap);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(285, 34);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.SaveMap);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAs.Size = new System.Drawing.Size(285, 34);
            this.SaveAs.Text = "Save As";
            this.SaveAs.Click += new System.EventHandler(this.SaveMapAs);
            // 
            // EditToolStrip
            // 
            this.EditToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Add});
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(58, 33);
            this.EditToolStrip.Text = "Edit";
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.Add.Size = new System.Drawing.Size(270, 34);
            this.Add.Text = "Add";
            // 
            // UEVersion
            // 
            this.UEVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UEVersion.BackColor = System.Drawing.SystemColors.Window;
            this.UEVersion.Items.AddRange(new object[] {
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
            "4.27"});
            this.UEVersion.Name = "UEVersion";
            this.UEVersion.Size = new System.Drawing.Size(135, 33);
            // 
            // Split
            // 
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.Location = new System.Drawing.Point(0, 37);
            this.Split.Name = "Split";
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.Controls.Add(this.Sidebar);
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.Controls.Add(this.Display);
            this.Split.Size = new System.Drawing.Size(1258, 627);
            this.Split.SplitterDistance = 500;
            this.Split.TabIndex = 1;
            // 
            // Sidebar
            // 
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sidebar.Location = new System.Drawing.Point(0, 0);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Sidebar.Panel1
            // 
            this.Sidebar.Panel1.Controls.Add(this.Objects);
            // 
            // Sidebar.Panel2
            // 
            this.Sidebar.Panel2.Controls.Add(this.PropertyList);
            this.Sidebar.Size = new System.Drawing.Size(500, 627);
            this.Sidebar.SplitterDistance = 229;
            this.Sidebar.TabIndex = 0;
            // 
            // Objects
            // 
            this.Objects.AutoScroll = true;
            this.Objects.AutoSize = true;
            this.Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Objects.Location = new System.Drawing.Point(0, 0);
            this.Objects.Name = "Objects";
            this.Objects.RootLists = ((System.Collections.Generic.Dictionary<string, System.Collections.IList>)(resources.GetObject("Objects.RootLists")));
            this.Objects.Size = new System.Drawing.Size(500, 229);
            this.Objects.TabIndex = 0;
            // 
            // PropertyList
            // 
            this.PropertyList.AutoScroll = true;
            this.PropertyList.AutoSize = true;
            this.PropertyList.BackColor = System.Drawing.SystemColors.Control;
            this.PropertyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyList.Location = new System.Drawing.Point(0, 0);
            this.PropertyList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PropertyList.Name = "PropertyList";
            this.PropertyList.Size = new System.Drawing.Size(500, 394);
            this.PropertyList.TabIndex = 0;
            // 
            // Display
            // 
            this.Display.AutoSize = true;
            this.Display.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Display.BackColor = System.Drawing.Color.Black;
            this.Display.CameraDistance = 25F;
            this.Display.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("Display.CameraTarget")));
            this.Display.CamRotX = 0F;
            this.Display.CamRotY = 0F;
            this.Display.CurrentShader = null;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Fov = 0.8F;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Display.Name = "Display";
            this.Display.NormPickingDepth = 0F;
            this.Display.ShowOrientationCube = true;
            this.Display.Size = new System.Drawing.Size(754, 627);
            this.Display.Stereoscopy = GL_EditorFramework.GL_Core.GL_ControlBase.StereoscopyType.DISABLED;
            this.Display.TabIndex = 0;
            this.Display.VSync = false;
            this.Display.ZFar = 32000F;
            this.Display.ZNear = 0.32F;
            // 
            // OpenMapDialog
            // 
            this.OpenMapDialog.Filter = "Unreal map files|*.umap";
            this.OpenMapDialog.InitialDirectory = ".\\";
            this.OpenMapDialog.Title = "Select the map you want to edit";
            // 
            // SaveMapDialog
            // 
            this.SaveMapDialog.Filter = "Unreal map files|*.umap";
            this.SaveMapDialog.InitialDirectory = ".\\";
            this.SaveMapDialog.Title = "Navigate to where you want to save the file";
            // 
            // Editor
            //
            this.Controls.Add(this.Split);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Editor";
            this.Text = "UE4 Map Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.OnLoad);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel2.ResumeLayout(false);
            this.Split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            this.Sidebar.Panel1.ResumeLayout(false);
            this.Sidebar.Panel1.PerformLayout();
            this.Sidebar.Panel2.ResumeLayout(false);
            this.Sidebar.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar)).EndInit();
            this.Sidebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip MenuStrip;
    private System.Windows.Forms.ToolStripMenuItem FileToolStrip;
    private System.Windows.Forms.ToolStripMenuItem Open;
    private System.Windows.Forms.ToolStripMenuItem Save;
    private System.Windows.Forms.ToolStripMenuItem SaveAs;
    private System.Windows.Forms.ToolStripMenuItem EditToolStrip;
    private System.Windows.Forms.ToolStripMenuItem Add;
    private System.Windows.Forms.ToolStripComboBox UEVersion;
    private System.Windows.Forms.SplitContainer Split;
    private System.Windows.Forms.SplitContainer Sidebar;
    private System.Windows.Forms.OpenFileDialog OpenMapDialog;
    private System.Windows.Forms.SaveFileDialog SaveMapDialog;
    private GL_ControlModern Display;
    private SceneListView Objects;
    private ObjectUIControl PropertyList;
}
