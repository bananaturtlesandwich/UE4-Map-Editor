using GL_EditorFramework;
using GL_EditorFramework.GL_Core;
using System.Windows.Forms;

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
        if (disposing && (components != null))components.Dispose();
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
            this.Display = new GL_EditorFramework.GL_Core.GL_ControlModern();
            this.OpenMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.AddObjectDialog = new System.Windows.Forms.OpenFileDialog();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar)).BeginInit();
            this.Sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 4F);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStrip,
            this.EditToolStrip,
            this.UEVersion});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.MenuStrip.Size = new System.Drawing.Size(1198, 32);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // FileToolStrip
            // 
            this.FileToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open,
            this.Save,
            this.SaveAs});
            this.FileToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.Size = new System.Drawing.Size(54, 28);
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
            this.EditToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(58, 28);
            this.EditToolStrip.Text = "Edit";
            // 
            // Add
            // 
            this.Add.Name = "Add";
            this.Add.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.Add.Size = new System.Drawing.Size(211, 34);
            this.Add.Text = "Add";
            this.Add.Click += new System.EventHandler(this.OnAddClicked);
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
            this.UEVersion.Size = new System.Drawing.Size(150, 28);
            // 
            // Split
            // 
            this.Split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split.Location = new System.Drawing.Point(0, 32);
            this.Split.Margin = new System.Windows.Forms.Padding(2);
            this.Split.Name = "Split";
            // 
            // Split.Panel1
            // 
            this.Split.Panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Split.Panel1.Controls.Add(this.Sidebar);
            // 
            // Split.Panel2
            // 
            this.Split.Panel2.Controls.Add(this.Display);
            this.Split.Size = new System.Drawing.Size(1198, 808);
            this.Split.SplitterDistance = 307;
            this.Split.TabIndex = 1;
            // 
            // Sidebar
            // 
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sidebar.Location = new System.Drawing.Point(0, 0);
            this.Sidebar.Margin = new System.Windows.Forms.Padding(2);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.Sidebar.Size = new System.Drawing.Size(307, 808);
            this.Sidebar.SplitterDistance = 347;
            this.Sidebar.TabIndex = 0;
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.Color.Black;
            this.Display.CameraDistance = 50F;
            this.Display.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("Display.CameraTarget")));
            this.Display.CamRotX = 0F;
            this.Display.CamRotY = 0F;
            this.Display.CurrentShader = null;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Fov = 0.7853982F;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Name = "Display";
            this.Display.NormPickingDepth = 0F;
            this.Display.ShowOrientationCube = true;
            this.Display.Size = new System.Drawing.Size(888, 808);
            this.Display.Stereoscopy = GL_EditorFramework.GL_Core.GL_ControlBase.StereoscopyType.DISABLED;
            this.Display.TabIndex = 0;
            this.Display.VSync = false;
            this.Display.ZFar = 100000F;
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
            // AddObjectDialog
            // 
            this.AddObjectDialog.Filter = "Unreal map files|*.umap";
            this.AddObjectDialog.InitialDirectory = ".\\";
            this.AddObjectDialog.Title = "Select a map you want to lift an object from";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 840);
            this.Controls.Add(this.Split);
            this.Controls.Add(this.MenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UE4 Map Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.OnLoad);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar)).EndInit();
            this.Sidebar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MenuStrip MenuStrip;
    private ToolStripMenuItem FileToolStrip;
    private ToolStripMenuItem Open;
    private ToolStripMenuItem Save;
    private ToolStripMenuItem SaveAs;
    private SplitContainer Split;
    private SplitContainer Sidebar;
    private OpenFileDialog OpenMapDialog;
    private ToolStripComboBox UEVersion;
    private SaveFileDialog SaveMapDialog;
    private ToolStripMenuItem EditToolStrip;
    private ToolStripMenuItem Add;
    private OpenFileDialog AddObjectDialog;
    private GL_ControlModern Display;
}