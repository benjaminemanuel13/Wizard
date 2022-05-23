namespace Wizard.Controls
{
    partial class AngularView
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
            this.label1 = new System.Windows.Forms.Label();
            this.authentication = new System.Windows.Forms.CheckBox();
            this.authenticationDropdown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Angular Web Site Specific View";
            // 
            // authentication
            // 
            this.authentication.AutoSize = true;
            this.authentication.Location = new System.Drawing.Point(50, 57);
            this.authentication.Name = "authentication";
            this.authentication.Size = new System.Drawing.Size(160, 17);
            this.authentication.TabIndex = 3;
            this.authentication.Text = "With Asp.Net Authentication";
            this.authentication.UseVisualStyleBackColor = true;
            this.authentication.CheckedChanged += new System.EventHandler(this.authentication_CheckedChanged);
            // 
            // authenticationDropdown
            // 
            this.authenticationDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authenticationDropdown.FormattingEnabled = true;
            this.authenticationDropdown.Items.AddRange(new object[] {
            "None",
            "Windows",
            "Asp.Net"});
            this.authenticationDropdown.Location = new System.Drawing.Point(3, 16);
            this.authenticationDropdown.Name = "authenticationDropdown";
            this.authenticationDropdown.Size = new System.Drawing.Size(157, 21);
            this.authenticationDropdown.TabIndex = 4;
            this.authenticationDropdown.SelectedIndexChanged += new System.EventHandler(this.authenticationDropdown_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Authentication";
            // 
            // AngularView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.authenticationDropdown);
            this.Controls.Add(this.authentication);
            this.Controls.Add(this.label1);
            this.Name = "AngularView";
            this.Size = new System.Drawing.Size(341, 189);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox authentication;
        private System.Windows.Forms.ComboBox authenticationDropdown;
        private System.Windows.Forms.Label label2;
    }
}
