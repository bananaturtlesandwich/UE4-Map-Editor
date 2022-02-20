namespace UE4_Map_Editor
{
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            this.btnAdd = new System.Windows.Forms.Button();
            this.Details_Display = new System.Windows.Forms.SplitContainer();
            this.Details = new System.Windows.Forms.TableLayoutPanel();
            this.Properties = new GL_EditorFramework.ObjectUIControl();
            this.MapObjects = new GL_EditorFramework.SceneListView();
            this.Display = new GL_EditorFramework.GL_Core.GL_ControlModern();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Editor = new System.Windows.Forms.SplitContainer();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMapPak = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMapUmap = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.UEVersion = new System.Windows.Forms.ToolStripComboBox();
            this.umapDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Details_Display)).BeginInit();
            this.Details_Display.Panel1.SuspendLayout();
            this.Details_Display.Panel2.SuspendLayout();
            this.Details_Display.SuspendLayout();
            this.Details.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuStrip_Editor)).BeginInit();
            this.MenuStrip_Editor.Panel1.SuspendLayout();
            this.MenuStrip_Editor.Panel2.SuspendLayout();
            this.MenuStrip_Editor.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(357, 37);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Object";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // Details_Display
            // 
            this.Details_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Details_Display.Location = new System.Drawing.Point(0, 0);
            this.Details_Display.Margin = new System.Windows.Forms.Padding(4);
            this.Details_Display.Name = "Details_Display";
            // 
            // Details_Display.Panel1
            // 
            this.Details_Display.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Details_Display.Panel1.Controls.Add(this.Details);
            // 
            // Details_Display.Panel2
            // 
            this.Details_Display.Panel2.Controls.Add(this.Display);
            this.Details_Display.Size = new System.Drawing.Size(1331, 890);
            this.Details_Display.SplitterDistance = 365;
            this.Details_Display.SplitterWidth = 5;
            this.Details_Display.TabIndex = 7;
            // 
            // Details
            // 
            this.Details.AutoScroll = true;
            this.Details.ColumnCount = 1;
            this.Details.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Details.Controls.Add(this.Properties, 0, 2);
            this.Details.Controls.Add(this.btnAdd, 0, 0);
            this.Details.Controls.Add(this.MapObjects, 0, 1);
            this.Details.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Details.Location = new System.Drawing.Point(0, 0);
            this.Details.Name = "Details";
            this.Details.RowCount = 3;
            this.Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.67742F));
            this.Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.32258F));
            this.Details.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 417F));
            this.Details.Size = new System.Drawing.Size(365, 890);
            this.Details.TabIndex = 7;
            // 
            // Properties
            // 
            this.Properties.AutoScroll = true;
            this.Properties.BackColor = System.Drawing.SystemColors.Control;
            this.Properties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Properties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Properties.Location = new System.Drawing.Point(5, 477);
            this.Properties.Margin = new System.Windows.Forms.Padding(5);
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(355, 408);
            this.Properties.TabIndex = 5;
            // 
            // MapObjects
            // 
            this.MapObjects.AutoScroll = true;
            this.MapObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapObjects.Location = new System.Drawing.Point(4, 49);
            this.MapObjects.Margin = new System.Windows.Forms.Padding(4);
            this.MapObjects.Name = "MapObjects";
            this.MapObjects.RootLists = ((System.Collections.Generic.Dictionary<string, System.Collections.IList>)(resources.GetObject("MapObjects.RootLists")));
            this.MapObjects.Size = new System.Drawing.Size(357, 419);
            this.MapObjects.TabIndex = 6;
            this.MapObjects.ItemClicked += new GL_EditorFramework.ItemClickedEventHandler(this.SceneListView1_ItemDoubleClicked);
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.Color.Black;
            this.Display.CameraDistance = 10F;
            this.Display.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("Display.CameraTarget")));
            this.Display.CamRotX = 0F;
            this.Display.CamRotY = 0F;
            this.Display.ContextMenuStrip = this.ContextMenu;
            this.Display.CurrentShader = null;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Fov = 0.7853982F;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Margin = new System.Windows.Forms.Padding(5);
            this.Display.Name = "Display";
            this.Display.NormPickingDepth = 0F;
            this.Display.ShowOrientationCube = true;
            this.Display.Size = new System.Drawing.Size(961, 890);
            this.Display.Stereoscopy = GL_EditorFramework.GL_Core.GL_ControlBase.StereoscopyType.DISABLED;
            this.Display.TabIndex = 1;
            this.Display.VSync = false;
            this.Display.ZFar = 32000F;
            this.Display.ZNear = 0.32F;
            // 
            // ContextMenu
            // 
            this.ContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.showAllToolStripMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(137, 52);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.showAllToolStripMenuItem.Text = "Show All";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.ShowAllToolStripMenuItem_Click);
            // 
            // MenuStrip_Editor
            // 
            this.MenuStrip_Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuStrip_Editor.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_Editor.Name = "MenuStrip_Editor";
            this.MenuStrip_Editor.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MenuStrip_Editor.Panel1
            // 
            this.MenuStrip_Editor.Panel1.Controls.Add(this.MenuStrip);
            // 
            // MenuStrip_Editor.Panel2
            // 
            this.MenuStrip_Editor.Panel2.Controls.Add(this.Details_Display);
            this.MenuStrip_Editor.Size = new System.Drawing.Size(1331, 919);
            this.MenuStrip_Editor.SplitterDistance = 25;
            this.MenuStrip_Editor.TabIndex = 9;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.MenuStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStrip,
            this.UEVersion});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1331, 25);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // FileStrip
            // 
            this.FileStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMapPak,
            this.OpenMapUmap,
            this.SaveAs});
            this.FileStrip.Name = "FileStrip";
            this.FileStrip.Size = new System.Drawing.Size(46, 21);
            this.FileStrip.Text = "File";
            // 
            // OpenMapPak
            // 
            this.OpenMapPak.Name = "OpenMapPak";
            this.OpenMapPak.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMapPak.Size = new System.Drawing.Size(294, 26);
            this.OpenMapPak.Text = "Open Map From Pak";
            // 
            // OpenMapUmap
            // 
            this.OpenMapUmap.Name = "OpenMapUmap";
            this.OpenMapUmap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.O)));
            this.OpenMapUmap.Size = new System.Drawing.Size(294, 26);
            this.OpenMapUmap.Text = "Open Map From .umap";
            this.OpenMapUmap.Click += new System.EventHandler(this.OpenMapUmap_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAs.Size = new System.Drawing.Size(294, 26);
            this.SaveAs.Text = "Save As";
            // 
            // UEVersion
            // 
            this.UEVersion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UEVersion.Items.AddRange(new object[] {
            "Unknown Version",
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
            this.UEVersion.Margin = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.UEVersion.Name = "UEVersion";
            this.UEVersion.Size = new System.Drawing.Size(150, 21);
            this.UEVersion.Text = "Unknown Version";
            // 
            // umapDialog
            // 
            this.umapDialog.DefaultExt = "umap";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 919);
            this.Controls.Add(this.MenuStrip_Editor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Editor";
            this.Text = "UE4 Map Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Details_Display.Panel1.ResumeLayout(false);
            this.Details_Display.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Details_Display)).EndInit();
            this.Details_Display.ResumeLayout(false);
            this.Details.ResumeLayout(false);
            this.ContextMenu.ResumeLayout(false);
            this.MenuStrip_Editor.Panel1.ResumeLayout(false);
            this.MenuStrip_Editor.Panel1.PerformLayout();
            this.MenuStrip_Editor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MenuStrip_Editor)).EndInit();
            this.MenuStrip_Editor.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private GL_EditorFramework.ObjectUIControl Properties;
        private GL_EditorFramework.SceneListView MapObjects;
        private System.Windows.Forms.SplitContainer Details_Display;
        private new System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private GL_EditorFramework.GL_Core.GL_ControlModern Display;
        private System.Windows.Forms.SplitContainer MenuStrip_Editor;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenMapPak;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.TableLayoutPanel Details;
        private System.Windows.Forms.ToolStripMenuItem OpenMapUmap;
        private System.Windows.Forms.OpenFileDialog umapDialog;
        public System.Windows.Forms.ToolStripComboBox UEVersion;
    }
}

