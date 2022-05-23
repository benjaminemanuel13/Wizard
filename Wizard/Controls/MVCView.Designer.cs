namespace Wizard.Controls
{
    partial class MVCView
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
            this.authentication = new System.Windows.Forms.CheckBox();
            this.controllers = new System.Windows.Forms.ListBox();
            this.delete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.conrollerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // authentication
            // 
            this.authentication.AutoSize = true;
            this.authentication.Location = new System.Drawing.Point(15, 12);
            this.authentication.Name = "authentication";
            this.authentication.Size = new System.Drawing.Size(166, 17);
            this.authentication.TabIndex = 2;
            this.authentication.Text = "With Windows Authentication";
            this.authentication.UseVisualStyleBackColor = true;
            this.authentication.CheckedChanged += new System.EventHandler(this.authentication_CheckedChanged);
            // 
            // controllers
            // 
            this.controllers.FormattingEnabled = true;
            this.controllers.Location = new System.Drawing.Point(15, 53);
            this.controllers.Name = "controllers";
            this.controllers.Size = new System.Drawing.Size(120, 95);
            this.controllers.TabIndex = 12;
            this.controllers.SelectedIndexChanged += new System.EventHandler(this.controllers_SelectedIndexChanged);
            // 
            // delete
            // 
            this.delete.Enabled = false;
            this.delete.Location = new System.Drawing.Point(170, 111);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 11;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // edit
            // 
            this.edit.Enabled = false;
            this.edit.Location = new System.Drawing.Point(170, 82);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(75, 23);
            this.edit.TabIndex = 10;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(170, 53);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 9;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // conrollerLabel
            // 
            this.conrollerLabel.AutoSize = true;
            this.conrollerLabel.Location = new System.Drawing.Point(12, 37);
            this.conrollerLabel.Name = "conrollerLabel";
            this.conrollerLabel.Size = new System.Drawing.Size(56, 13);
            this.conrollerLabel.TabIndex = 8;
            this.conrollerLabel.Text = "Controllers";
            // 
            // MVCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.controllers);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.add);
            this.Controls.Add(this.conrollerLabel);
            this.Controls.Add(this.authentication);
            this.Name = "MVCView";
            this.Size = new System.Drawing.Size(341, 189);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox authentication;
        private System.Windows.Forms.ListBox controllers;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label conrollerLabel;
    }
}
