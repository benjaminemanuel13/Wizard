namespace Wizard.Forms
{
    partial class ControllerForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.method = new System.Windows.Forms.GroupBox();
            this.cancelMethod = new System.Windows.Forms.Button();
            this.saveMethod = new System.Windows.Forms.Button();
            this.deleteMethod = new System.Windows.Forms.CheckBox();
            this.putMethod = new System.Windows.Forms.CheckBox();
            this.methodName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.postMethod = new System.Windows.Forms.CheckBox();
            this.getMethod = new System.Windows.Forms.CheckBox();
            this.deleteThisMethod = new System.Windows.Forms.Button();
            this.editMethod = new System.Windows.Forms.Button();
            this.addMethod = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.methods = new System.Windows.Forms.ListBox();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.method.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Controller Name";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(22, 38);
            this.name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(248, 26);
            this.name.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.method);
            this.groupBox1.Controls.Add(this.deleteThisMethod);
            this.groupBox1.Controls.Add(this.editMethod);
            this.groupBox1.Controls.Add(this.addMethod);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.methods);
            this.groupBox1.Location = new System.Drawing.Point(22, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(777, 432);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Methods";
            // 
            // method
            // 
            this.method.Controls.Add(this.cancelMethod);
            this.method.Controls.Add(this.saveMethod);
            this.method.Controls.Add(this.deleteMethod);
            this.method.Controls.Add(this.putMethod);
            this.method.Controls.Add(this.methodName);
            this.method.Controls.Add(this.label3);
            this.method.Controls.Add(this.postMethod);
            this.method.Controls.Add(this.getMethod);
            this.method.Enabled = false;
            this.method.Location = new System.Drawing.Point(442, 65);
            this.method.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.method.Name = "method";
            this.method.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.method.Size = new System.Drawing.Size(300, 331);
            this.method.TabIndex = 5;
            this.method.TabStop = false;
            this.method.Text = "Method";
            // 
            // cancelMethod
            // 
            this.cancelMethod.Location = new System.Drawing.Point(178, 272);
            this.cancelMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelMethod.Name = "cancelMethod";
            this.cancelMethod.Size = new System.Drawing.Size(112, 35);
            this.cancelMethod.TabIndex = 7;
            this.cancelMethod.Text = "Cancel";
            this.cancelMethod.UseVisualStyleBackColor = true;
            this.cancelMethod.Click += new System.EventHandler(this.cancelMethod_Click);
            // 
            // saveMethod
            // 
            this.saveMethod.Location = new System.Drawing.Point(57, 272);
            this.saveMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveMethod.Name = "saveMethod";
            this.saveMethod.Size = new System.Drawing.Size(112, 35);
            this.saveMethod.TabIndex = 6;
            this.saveMethod.Text = "Save";
            this.saveMethod.UseVisualStyleBackColor = true;
            this.saveMethod.Click += new System.EventHandler(this.saveMethod_Click);
            // 
            // deleteMethod
            // 
            this.deleteMethod.AutoSize = true;
            this.deleteMethod.Location = new System.Drawing.Point(27, 223);
            this.deleteMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteMethod.Name = "deleteMethod";
            this.deleteMethod.Size = new System.Drawing.Size(140, 24);
            this.deleteMethod.TabIndex = 5;
            this.deleteMethod.Text = "Delete Method";
            this.deleteMethod.UseVisualStyleBackColor = true;
            // 
            // putMethod
            // 
            this.putMethod.AutoSize = true;
            this.putMethod.Location = new System.Drawing.Point(27, 188);
            this.putMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.putMethod.Name = "putMethod";
            this.putMethod.Size = new System.Drawing.Size(117, 24);
            this.putMethod.TabIndex = 4;
            this.putMethod.Text = "Put Method";
            this.putMethod.UseVisualStyleBackColor = true;
            // 
            // methodName
            // 
            this.methodName.Location = new System.Drawing.Point(27, 69);
            this.methodName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.methodName.Name = "methodName";
            this.methodName.Size = new System.Drawing.Size(223, 26);
            this.methodName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // postMethod
            // 
            this.postMethod.AutoSize = true;
            this.postMethod.Location = new System.Drawing.Point(27, 152);
            this.postMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.postMethod.Name = "postMethod";
            this.postMethod.Size = new System.Drawing.Size(125, 24);
            this.postMethod.TabIndex = 1;
            this.postMethod.Text = "Post Method";
            this.postMethod.UseVisualStyleBackColor = true;
            // 
            // getMethod
            // 
            this.getMethod.AutoSize = true;
            this.getMethod.Location = new System.Drawing.Point(27, 117);
            this.getMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.getMethod.Name = "getMethod";
            this.getMethod.Size = new System.Drawing.Size(120, 24);
            this.getMethod.TabIndex = 0;
            this.getMethod.Text = "Get Method";
            this.getMethod.UseVisualStyleBackColor = true;
            // 
            // deleteThisMethod
            // 
            this.deleteThisMethod.Enabled = false;
            this.deleteThisMethod.Location = new System.Drawing.Point(282, 154);
            this.deleteThisMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteThisMethod.Name = "deleteThisMethod";
            this.deleteThisMethod.Size = new System.Drawing.Size(112, 35);
            this.deleteThisMethod.TabIndex = 4;
            this.deleteThisMethod.Text = "Delete";
            this.deleteThisMethod.UseVisualStyleBackColor = true;
            this.deleteThisMethod.Click += new System.EventHandler(this.deleteThisMethod_Click);
            // 
            // editMethod
            // 
            this.editMethod.Enabled = false;
            this.editMethod.Location = new System.Drawing.Point(282, 109);
            this.editMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.editMethod.Name = "editMethod";
            this.editMethod.Size = new System.Drawing.Size(112, 35);
            this.editMethod.TabIndex = 3;
            this.editMethod.Text = "Edit";
            this.editMethod.UseVisualStyleBackColor = true;
            this.editMethod.Click += new System.EventHandler(this.editMethod_Click);
            // 
            // addMethod
            // 
            this.addMethod.Location = new System.Drawing.Point(282, 65);
            this.addMethod.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addMethod.Name = "addMethod";
            this.addMethod.Size = new System.Drawing.Size(112, 35);
            this.addMethod.TabIndex = 2;
            this.addMethod.Text = "Add";
            this.addMethod.UseVisualStyleBackColor = true;
            this.addMethod.Click += new System.EventHandler(this.addMethod_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // methods
            // 
            this.methods.FormattingEnabled = true;
            this.methods.ItemHeight = 20;
            this.methods.Location = new System.Drawing.Point(27, 65);
            this.methods.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.methods.Name = "methods";
            this.methods.Size = new System.Drawing.Size(244, 204);
            this.methods.TabIndex = 0;
            this.methods.SelectedIndexChanged += new System.EventHandler(this.methods_SelectedIndexChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(566, 535);
            this.save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(112, 35);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(687, 535);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(112, 35);
            this.cancel.TabIndex = 4;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 594);
            this.ControlBox = false;
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControllerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.ControllerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.method.ResumeLayout(false);
            this.method.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox method;
        private System.Windows.Forms.Button cancelMethod;
        private System.Windows.Forms.Button saveMethod;
        private System.Windows.Forms.CheckBox deleteMethod;
        private System.Windows.Forms.CheckBox putMethod;
        private System.Windows.Forms.TextBox methodName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox postMethod;
        private System.Windows.Forms.CheckBox getMethod;
        private System.Windows.Forms.Button deleteThisMethod;
        private System.Windows.Forms.Button editMethod;
        private System.Windows.Forms.Button addMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox methods;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
    }
}