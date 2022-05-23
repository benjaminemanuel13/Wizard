namespace Wizard
{
    partial class WizardForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Solution");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editProject = new System.Windows.Forms.Button();
            this.deleteProject = new System.Windows.Forms.Button();
            this.newProject = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelProject = new System.Windows.Forms.Button();
            this.saveProject = new System.Windows.Forms.Button();
            this.projectType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.projectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webApiPanel = new Wizard.Controls.WebApiView();
            this.mvcView = new Wizard.Controls.MVCView();
            this.angularView = new Wizard.Controls.AngularView();
            this.dataPanel = new Wizard.Controls.DataPanelView();
            this.servicePanel = new Wizard.Controls.ServiceLibrarySpecificView();
            this.label4 = new System.Windows.Forms.Label();
            this.nugetPackages = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.projectTree = new System.Windows.Forms.TreeView();
            this.close = new System.Windows.Forms.Button();
            this.cancelAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.editProject);
            this.groupBox1.Controls.Add(this.deleteProject);
            this.groupBox1.Controls.Add(this.newProject);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.projectTree);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects To Create";
            // 
            // editProject
            // 
            this.editProject.Enabled = false;
            this.editProject.Location = new System.Drawing.Point(98, 352);
            this.editProject.Name = "editProject";
            this.editProject.Size = new System.Drawing.Size(75, 23);
            this.editProject.TabIndex = 4;
            this.editProject.Text = "Edit >>";
            this.editProject.UseVisualStyleBackColor = true;
            this.editProject.Click += new System.EventHandler(this.editProject_Click);
            // 
            // deleteProject
            // 
            this.deleteProject.Enabled = false;
            this.deleteProject.Location = new System.Drawing.Point(179, 352);
            this.deleteProject.Name = "deleteProject";
            this.deleteProject.Size = new System.Drawing.Size(75, 23);
            this.deleteProject.TabIndex = 3;
            this.deleteProject.Text = "Delete";
            this.deleteProject.UseVisualStyleBackColor = true;
            // 
            // newProject
            // 
            this.newProject.Location = new System.Drawing.Point(17, 352);
            this.newProject.Name = "newProject";
            this.newProject.Size = new System.Drawing.Size(75, 23);
            this.newProject.TabIndex = 2;
            this.newProject.Text = "Add New";
            this.newProject.UseVisualStyleBackColor = true;
            this.newProject.Click += new System.EventHandler(this.newProject_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancelProject);
            this.groupBox2.Controls.Add(this.saveProject);
            this.groupBox2.Controls.Add(this.projectType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.projectName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(274, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(935, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project";
            // 
            // cancelProject
            // 
            this.cancelProject.Enabled = false;
            this.cancelProject.Location = new System.Drawing.Point(843, 300);
            this.cancelProject.Name = "cancelProject";
            this.cancelProject.Size = new System.Drawing.Size(75, 23);
            this.cancelProject.TabIndex = 5;
            this.cancelProject.Text = "Cancel";
            this.cancelProject.UseVisualStyleBackColor = true;
            this.cancelProject.Click += new System.EventHandler(this.cancelProject_Click);
            // 
            // saveProject
            // 
            this.saveProject.Enabled = false;
            this.saveProject.Location = new System.Drawing.Point(762, 300);
            this.saveProject.Name = "saveProject";
            this.saveProject.Size = new System.Drawing.Size(75, 23);
            this.saveProject.TabIndex = 4;
            this.saveProject.Text = "Save";
            this.saveProject.UseVisualStyleBackColor = true;
            this.saveProject.Click += new System.EventHandler(this.saveProject_Click);
            // 
            // projectType
            // 
            this.projectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectType.Enabled = false;
            this.projectType.FormattingEnabled = true;
            this.projectType.Location = new System.Drawing.Point(22, 112);
            this.projectType.Name = "projectType";
            this.projectType.Size = new System.Drawing.Size(254, 21);
            this.projectType.TabIndex = 3;
            this.projectType.SelectedIndexChanged += new System.EventHandler(this.projectType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project Type";
            // 
            // projectName
            // 
            this.projectName.Enabled = false;
            this.projectName.Location = new System.Drawing.Point(22, 45);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(254, 20);
            this.projectName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webApiPanel);
            this.groupBox3.Controls.Add(this.mvcView);
            this.groupBox3.Controls.Add(this.angularView);
            this.groupBox3.Controls.Add(this.dataPanel);
            this.groupBox3.Controls.Add(this.servicePanel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.nugetPackages);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(307, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(611, 265);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configure Project";
            // 
            // webApiPanel
            // 
            this.webApiPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.webApiPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webApiPanel.Enabled = false;
            this.webApiPanel.Location = new System.Drawing.Point(247, 53);
            this.webApiPanel.Name = "webApiPanel";
            this.webApiPanel.Size = new System.Drawing.Size(341, 189);
            this.webApiPanel.TabIndex = 5;
            this.webApiPanel.Visible = false;
            // 
            // mvcView
            // 
            this.mvcView.Location = new System.Drawing.Point(247, 53);
            this.mvcView.Name = "mvcView";
            this.mvcView.Size = new System.Drawing.Size(341, 189);
            this.mvcView.TabIndex = 8;
            // 
            // angularView
            // 
            this.angularView.Location = new System.Drawing.Point(247, 53);
            this.angularView.Name = "angularView";
            this.angularView.Size = new System.Drawing.Size(341, 189);
            this.angularView.TabIndex = 7;
            // 
            // dataPanel
            // 
            this.dataPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataPanel.Location = new System.Drawing.Point(247, 53);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(341, 189);
            this.dataPanel.TabIndex = 2;
            // 
            // servicePanel
            // 
            this.servicePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.servicePanel.Location = new System.Drawing.Point(247, 53);
            this.servicePanel.Name = "servicePanel";
            this.servicePanel.Size = new System.Drawing.Size(341, 189);
            this.servicePanel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Project Specifics";
            // 
            // nugetPackages
            // 
            this.nugetPackages.CheckOnClick = true;
            this.nugetPackages.Enabled = false;
            this.nugetPackages.FormattingEnabled = true;
            this.nugetPackages.Location = new System.Drawing.Point(24, 53);
            this.nugetPackages.Name = "nugetPackages";
            this.nugetPackages.Size = new System.Drawing.Size(199, 184);
            this.nugetPackages.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nuget Packages";
            // 
            // projectTree
            // 
            this.projectTree.Location = new System.Drawing.Point(17, 54);
            this.projectTree.Name = "projectTree";
            treeNode1.Name = "Solution";
            treeNode1.Tag = "Root";
            treeNode1.Text = "Solution";
            this.projectTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.projectTree.Size = new System.Drawing.Size(241, 291);
            this.projectTree.TabIndex = 0;
            this.projectTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.projectTree_AfterSelect);
            this.projectTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.projectTree_NodeMouseClick);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(1088, 421);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 1;
            this.close.Text = "Finish";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // cancelAll
            // 
            this.cancelAll.Location = new System.Drawing.Point(1169, 421);
            this.cancelAll.Name = "cancelAll";
            this.cancelAll.Size = new System.Drawing.Size(75, 23);
            this.cancelAll.TabIndex = 2;
            this.cancelAll.Text = "Cancel";
            this.cancelAll.UseVisualStyleBackColor = true;
            this.cancelAll.Click += new System.EventHandler(this.cancelAll_Click);
            // 
            // WizardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 457);
            this.ControlBox = false;
            this.Controls.Add(this.cancelAll);
            this.Controls.Add(this.close);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WizardForm";
            this.Load += new System.EventHandler(this.WizardForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView projectTree;
        private System.Windows.Forms.TextBox projectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox projectType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button deleteProject;
        private System.Windows.Forms.Button newProject;
        private System.Windows.Forms.Button cancelProject;
        private System.Windows.Forms.Button saveProject;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button editProject;
        private System.Windows.Forms.CheckedListBox nugetPackages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Controls.ServiceLibrarySpecificView servicePanel;
        private Controls.WebApiView webApiPanel;
        private Controls.DataPanelView dataPanel;
        private System.Windows.Forms.Button cancelAll;
        private Controls.MVCView mvcView;
        private Controls.AngularView angularView;
    }
}