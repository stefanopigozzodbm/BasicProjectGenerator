
namespace Basic_Project_Generator.UserInterfaces
{
    partial class NewTiaPortalProject
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
            this.lab_ProjectName = new System.Windows.Forms.Label();
            this.txb_ProjectName = new System.Windows.Forms.TextBox();
            this.lab_Path = new System.Windows.Forms.Label();
            this.txb_Path = new System.Windows.Forms.TextBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Path = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lab_ProjectName
            // 
            this.lab_ProjectName.Location = new System.Drawing.Point(12, 19);
            this.lab_ProjectName.Name = "lab_ProjectName";
            this.lab_ProjectName.Size = new System.Drawing.Size(81, 20);
            this.lab_ProjectName.TabIndex = 0;
            this.lab_ProjectName.Text = "Project name";
            // 
            // txb_ProjectName
            // 
            this.txb_ProjectName.Location = new System.Drawing.Point(99, 19);
            this.txb_ProjectName.Name = "txb_ProjectName";
            this.txb_ProjectName.Size = new System.Drawing.Size(254, 20);
            this.txb_ProjectName.TabIndex = 1;
            this.txb_ProjectName.TextChanged += new System.EventHandler(this.ProjectName_TextChanged);
            // 
            // lab_Path
            // 
            this.lab_Path.Location = new System.Drawing.Point(12, 45);
            this.lab_Path.Name = "lab_Path";
            this.lab_Path.Size = new System.Drawing.Size(81, 20);
            this.lab_Path.TabIndex = 2;
            this.lab_Path.Text = "Directory path";
            // 
            // txb_Path
            // 
            this.txb_Path.Location = new System.Drawing.Point(99, 45);
            this.txb_Path.Name = "txb_Path";
            this.txb_Path.Size = new System.Drawing.Size(254, 20);
            this.txb_Path.TabIndex = 3;
            this.txb_Path.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(149, 71);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(99, 23);
            this.btn_Create.TabIndex = 5;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(254, 71);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(99, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Path
            // 
            this.btn_Path.Location = new System.Drawing.Point(359, 45);
            this.btn_Path.Name = "btn_Path";
            this.btn_Path.Size = new System.Drawing.Size(29, 20);
            this.btn_Path.TabIndex = 4;
            this.btn_Path.Text = "...";
            this.btn_Path.UseVisualStyleBackColor = true;
            this.btn_Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // NewTiaPortalProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 116);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Path);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.txb_Path);
            this.Controls.Add(this.lab_Path);
            this.Controls.Add(this.txb_ProjectName);
            this.Controls.Add(this.lab_ProjectName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTiaPortalProject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create a new TIA Portal project";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewTiaPortalProject_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_ProjectName;
        private System.Windows.Forms.TextBox txb_ProjectName;
        private System.Windows.Forms.Label lab_Path;
        private System.Windows.Forms.TextBox txb_Path;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Path;
    }
}