namespace Wizard.Controls
{
    partial class WebApiView
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
            this.minimal = new System.Windows.Forms.CheckBox();
            this.conrollerLabel = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.controllers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // minimal
            // 
            this.minimal.AutoSize = true;
            this.minimal.Location = new System.Drawing.Point(16, 19);
            this.minimal.Name = "minimal";
            this.minimal.Size = new System.Drawing.Size(79, 17);
            this.minimal.TabIndex = 1;
            this.minimal.Text = "Minimal Api";
            this.minimal.UseVisualStyleBackColor = true;
            this.minimal.CheckedChanged += new System.EventHandler(this.minimal_CheckedChanged);
            // 
            // conrollerLabel
            // 
            this.conrollerLabel.AutoSize = true;
            this.conrollerLabel.Location = new System.Drawing.Point(13, 52);
            this.conrollerLabel.Name = "conrollerLabel";
            this.conrollerLabel.Size = new System.Drawing.Size(56, 13);
            this.conrollerLabel.TabIndex = 3;
            this.conrollerLabel.Text = "Controllers";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(171, 68);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 4;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // edit
            // 
            this.edit.Enabled = false;
            this.edit.Location = new System.Drawing.Point(171, 97);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(75, 23);
            this.edit.TabIndex = 5;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // delete
            // 
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(171, 126);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 6;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // controllers
            // 
            this.controllers.FormattingEnabled = true;
            this.controllers.Location = new System.Drawing.Point(16, 68);
            this.controllers.Name = "controllers";
            this.controllers.Size = new System.Drawing.Size(120, 95);
            this.controllers.TabIndex = 7;
            this.controllers.SelectedIndexChanged += new System.EventHandler(this.controllers_SelectedIndexChanged);
            // 
            // WebApiView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controllers);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.conrollerLabel);
            this.Controls.Add(this.minimal);
            this.Name = "WebApiView";
            this.Size = new System.Drawing.Size(341, 189);
            this.Load += new System.EventHandler(this.WebApiView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox minimal;
        private System.Windows.Forms.Label conrollerLabel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ListBox controllers;
    }
}
