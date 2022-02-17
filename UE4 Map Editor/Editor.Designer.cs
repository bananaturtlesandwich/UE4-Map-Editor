namespace Example
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MapObjects = new GL_EditorFramework.SceneListView();
            this.Properties = new GL_EditorFramework.ObjectUIControl();
            this.Display = new GL_EditorFramework.GL_Core.GL_ControlModern();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Editor = new System.Windows.Forms.SplitContainer();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapFromPakCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowCtrlNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Details_Display)).BeginInit();
            this.Details_Display.Panel1.SuspendLayout();
            this.Details_Display.Panel2.SuspendLayout();
            this.Details_Display.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 28);
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
            this.Details_Display.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // Details_Display.Panel2
            // 
            this.Details_Display.Panel2.Controls.Add(this.Display);
            this.Details_Display.Size = new System.Drawing.Size(1331, 890);
            this.Details_Display.SplitterDistance = 448;
            this.Details_Display.SplitterWidth = 5;
            this.Details_Display.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.MapObjects);
            this.flowLayoutPanel1.Controls.Add(this.Properties);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(448, 890);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // MapObjects
            // 
            this.MapObjects.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MapObjects.Location = new System.Drawing.Point(4, 40);
            this.MapObjects.Margin = new System.Windows.Forms.Padding(4);
            this.MapObjects.Name = "MapObjects";
            this.MapObjects.RootLists = ((System.Collections.Generic.Dictionary<string, System.Collections.IList>)(resources.GetObject("MapObjects.RootLists")));
            this.MapObjects.Size = new System.Drawing.Size(433, 333);
            this.MapObjects.TabIndex = 6;
            this.MapObjects.ItemClicked += new GL_EditorFramework.ItemClickedEventHandler(this.SceneListView1_ItemDoubleClicked);
            // 
            // Properties
            // 
            this.Properties.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Properties.AutoScroll = true;
            this.Properties.BackColor = System.Drawing.SystemColors.Control;
            this.Properties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Properties.Location = new System.Drawing.Point(5, 382);
            this.Properties.Margin = new System.Windows.Forms.Padding(5);
            this.Properties.Name = "Properties";
            this.Properties.Size = new System.Drawing.Size(433, 494);
            this.Properties.TabIndex = 5;
            // 
            // Display
            // 
            this.Display.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Display.BackColor = System.Drawing.Color.Black;
            this.Display.CameraDistance = 10F;
            this.Display.CameraTarget = ((OpenTK.Vector3)(resources.GetObject("Display.CameraTarget")));
            this.Display.CamRotX = 0F;
            this.Display.CamRotY = 0F;
            this.Display.ContextMenuStrip = this.ContextMenu;
            this.Display.CurrentShader = null;
            this.Display.Fov = 0.7853982F;
            this.Display.Location = new System.Drawing.Point(4, 4);
            this.Display.Margin = new System.Windows.Forms.Padding(5);
            this.Display.Name = "Display";
            this.Display.NormPickingDepth = 0F;
            this.Display.ShowOrientationCube = true;
            this.Display.Size = new System.Drawing.Size(1645, 1246);
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
            this.ContextMenu.Name = "contextMenuStrip1";
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
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.newWindowCtrlNToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1331, 28);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "MenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapFromPakCtrlOToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMapFromPakCtrlOToolStripMenuItem
            // 
            this.openMapFromPakCtrlOToolStripMenuItem.Name = "openMapFromPakCtrlOToolStripMenuItem";
            this.openMapFromPakCtrlOToolStripMenuItem.Size = new System.Drawing.Size(284, 26);
            this.openMapFromPakCtrlOToolStripMenuItem.Text = "Open Map From Pak (Ctrl+O)";
            // 
            // newWindowCtrlNToolStripMenuItem
            // 
            this.newWindowCtrlNToolStripMenuItem.Name = "newWindowCtrlNToolStripMenuItem";
            this.newWindowCtrlNToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.newWindowCtrlNToolStripMenuItem.Text = "New Window (Ctrl+N)";
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
            this.Details_Display.Panel1.ResumeLayout(false);
            this.Details_Display.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Details_Display)).EndInit();
            this.Details_Display.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private GL_EditorFramework.GL_Core.GL_ControlModern Display;
        private System.Windows.Forms.SplitContainer MenuStrip_Editor;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapFromPakCtrlOToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem newWindowCtrlNToolStripMenuItem;
    }
}

