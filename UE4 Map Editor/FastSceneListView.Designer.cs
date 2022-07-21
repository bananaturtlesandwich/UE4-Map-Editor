namespace UE4MapEditor
{
    partial class FastSceneListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SceneObjects = new BrightIdeasSoftware.FastObjectListView();
            this.Object = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.SceneObjects)).BeginInit();
            this.SuspendLayout();
            // 
            // SceneObjects
            // 
            this.SceneObjects.AllColumns.Add(this.Object);
            this.SceneObjects.CellEditUseWholeCell = false;
            this.SceneObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Object});
            this.SceneObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SceneObjects.HideSelection = false;
            this.SceneObjects.Location = new System.Drawing.Point(0, 0);
            this.SceneObjects.Name = "SceneObjects";
            this.SceneObjects.ShowGroups = false;
            this.SceneObjects.Size = new System.Drawing.Size(300, 300);
            this.SceneObjects.TabIndex = 0;
            this.SceneObjects.UseCompatibleStateImageBehavior = false;
            this.SceneObjects.View = System.Windows.Forms.View.Details;
            this.SceneObjects.VirtualMode = true;
            // 
            // Object
            // 
            this.Object.IsButton = true;
            this.Object.IsEditable = false;
            // 
            // FastSceneListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SceneObjects);
            this.Name = "FastSceneListView";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.SceneObjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastObjectListView SceneObjects;
        private BrightIdeasSoftware.OLVColumn Object;
    }
}
