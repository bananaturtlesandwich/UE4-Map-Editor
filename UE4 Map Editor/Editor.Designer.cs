namespace UE4MapEditor
{
    partial class Editor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.UEVersion = new System.Windows.Forms.ToolStripComboBox();
            this.Split = new System.Windows.Forms.SplitContainer();
            this.Sidebar = new System.Windows.Forms.SplitContainer();
            this.Objects = new GL_EditorFramework.SceneListView();
            this.Display = new GL_EditorFramework.GL_Core.GL_ControlModern();
            this.Properties = new GL_EditorFramework.ObjectUIControl();
            this.DisplayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Focus = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split)).BeginInit();
            this.Split.Panel1.SuspendLayout();
            this.Split.Panel2.SuspendLayout();
            this.Split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar)).BeginInit();
            this.Sidebar.Panel1.SuspendLayout();
            this.Sidebar.SuspendLayout();
            this.DisplayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("Segoe UI", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStrip,
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
            this.FileToolStrip.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.Size = new System.Drawing.Size(46, 28);
            this.FileToolStrip.Text = "File";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open.Size = new System.Drawing.Size(233, 26);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.OpenMap);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save.Size = new System.Drawing.Size(233, 26);
            this.Save.Text = "Save";
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.S)));
            this.SaveAs.Size = new System.Drawing.Size(233, 26);
            this.SaveAs.Text = "Save As";
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
            this.Split.SplitterDistance = 308;
            this.Split.SplitterWidth = 3;
            this.Split.TabIndex = 1;
            // 
            // Sidebar
            // 
            this.Sidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Sidebar.Location = new System.Drawing.Point(0, 0);
            this.Sidebar.Margin = new System.Windows.Forms.Padding(2);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Sidebar.Panel1
            // 
            this.Sidebar.Panel1.Controls.Add(this.Objects);
            this.Sidebar.Size = new System.Drawing.Size(308, 808);
            this.Sidebar.SplitterDistance = 349;
            this.Sidebar.SplitterWidth = 3;
            this.Sidebar.TabIndex = 0;
            // 
            // Sidebar.Panel2
            //
            this.Sidebar.Panel2.Controls.Add(this.Properties);
            //
            // Objects
            // 
            this.Objects.AutoScroll = true;
            this.Objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Objects.Location = new System.Drawing.Point(0, 0);
            this.Objects.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.Objects.Name = "Objects";
            this.Objects.RootLists = ((System.Collections.Generic.Dictionary<string, System.Collections.IList>)(resources.GetObject("Objects.RootLists")));
            this.Objects.Size = new System.Drawing.Size(308, 349);
            this.Objects.TabIndex = 0;
            this.Objects.ItemClicked += new GL_EditorFramework.ItemClickedEventHandler(this.FocusObject);
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.Color.Black;
            this.Display.CameraDistance = 20F;
            this.Display.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("Display.CameraTarget")));
            this.Display.CamRotX = 0F;
            this.Display.CamRotY = 0F;
            this.Display.ContextMenuStrip = this.DisplayContextMenu;
            this.Display.CurrentShader = null;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Fov = 0.7853982F;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Name = "Display";
            this.Display.NormPickingDepth = 0F;
            this.Display.ShowOrientationCube = true;
            this.Display.Size = new System.Drawing.Size(887, 808);
            this.Display.Stereoscopy = GL_EditorFramework.GL_Core.GL_ControlBase.StereoscopyType.DISABLED;
            this.Display.TabIndex = 0;
            this.Display.VSync = false;
            this.Display.ZFar = 100000F;
            this.Display.ZNear = 0.32F;
            // 
            //Properties
            //
            this.Properties.AutoScroll = true;
            this.Properties.BackColor = System.Drawing.SystemColors.Control;
            this.Properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Properties.Location = new System.Drawing.Point(0, 0);
            this.Properties.Margin = new System.Windows.Forms.Padding(6);
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(398, 509);
            //
            // DisplayContextMenu
            // 
            this.DisplayContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DisplayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Focus});
            this.DisplayContextMenu.Name = "DisplayContextMenu";
            this.DisplayContextMenu.Size = new System.Drawing.Size(211, 56);
            // 
            // Focus
            // 
            this.Focus.Name = "Focus";
            this.Focus.Size = new System.Drawing.Size(210, 24);
            this.Focus.Text = "Focus";
            this.Focus.Click += new System.EventHandler(this.Focus_Click);
            // 
            // OpenMapDialog
            // 
            this.OpenMapDialog.Filter = "Unreal map files|*.umap";
            this.OpenMapDialog.InitialDirectory = ".\\";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
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
            this.Load += new System.EventHandler(this.OnLoad);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.Split.Panel1.ResumeLayout(false);
            this.Split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split)).EndInit();
            this.Split.ResumeLayout(false);
            this.Sidebar.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Sidebar)).EndInit();
            this.Sidebar.ResumeLayout(false);
            this.DisplayContextMenu.ResumeLayout(false);
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

        //GL Editor Controls
        private GL_EditorFramework.GL_Core.GL_ControlModern Display;
        private GL_EditorFramework.SceneListView Objects;
        private GL_EditorFramework.ObjectUIControl Properties;
        private OpenFileDialog OpenMapDialog;
        private ToolStripComboBox UEVersion;
        private ContextMenuStrip DisplayContextMenu;
        private ToolStripMenuItem Focus;
    }
}