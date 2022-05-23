using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wizard.Models;
using Wizard.Models.Extensions;

namespace Wizard
{
    public partial class WizardForm : Form
    {
        private List<ProjectType> _projectTypes = new List<ProjectType>() {
            new ProjectType() { Name="WebApi", Templates = new List<ProjectTemplate>(){ new ProjectTemplate() { Name= "Web Api", TemplateFilename = "WorksWebApi.zip" }, new ProjectTemplate() { Name = "Minimal Web Api", TemplateFilename = "WorksMinimalWebApi.zip" } }, Type = ProjectTypeEnum.WebApi },
            new ProjectType() { Name="MVC Web Site" , Templates = new List<ProjectTemplate>(){ new ProjectTemplate() { Name = "MVC Web Site", TemplateFilename = "WorksMvcWeb.zip" }, new ProjectTemplate() { Name= "Authenticated MVC Web Site", TemplateFilename = "WorksAuthMvcWeb.zip" } }, Type = ProjectTypeEnum.MVCWebsite },
            new ProjectType() { Name="Angular Web Site" , Templates = new List<ProjectTemplate>(){ new ProjectTemplate() { Name = "Angular Web Site", TemplateFilename = "WorksAngularWeb.zip" }, new ProjectTemplate() { Name = "Authenticated Angular Web Site", TemplateFilename = "WorksAuthAngularWeb.zip" }, new ProjectTemplate() { Name = "Windows Auth Angular Web Site", TemplateFilename = "WorksWindowsAngularWeb.zip" } }, Type = ProjectTypeEnum.AngularWebsite },
            new ProjectType() { Name="Service Library", Templates = new List<ProjectTemplate>(){ new ProjectTemplate() { TemplateFilename = "WorksServiceLibrary.zip" } }, Type = ProjectTypeEnum.ServiceLibrary },
            new ProjectType() { Name="Data Layer", Templates = new List<ProjectTemplate>(){ new ProjectTemplate() { TemplateFilename = "WorksDataLayer.zip" } } , Type = ProjectTypeEnum.DataLayer },
            new ProjectType() { Name="Console App", Templates = new List<ProjectTemplate>(){ new ProjectTemplate() { TemplateFilename = "WorksConsole.zip" } }, Type = ProjectTypeEnum.Console }
        };

        private List<ProjectNuget> _nugetItemPackages = new List<ProjectNuget>() {
            new ProjectNuget(){ DisplayName = "Newtonsoft Json", Name ="Newtonsoft.Json", Version = "13.0.1", Default = true },
            new ProjectNuget(){ DisplayName = "AWS Kinesis SDK", Name ="AWSSDK.Kinesis", Version = "3.7.1.54", Default = false },
            new ProjectNuget(){ DisplayName = "EasyNetQ (for RabbitMQ)", Name ="EasyNetQ", Version = "6.3.1", Default = false }
        };

        private bool editing = false;
        private ProjectTypeEnum selectedType = ProjectTypeEnum.WebApi;
        private ProjectType currentProjectType;
        private WorksProject thisProject;

        private Properties _properties = new Properties();

        public WizardForm()
        {
            InitializeComponent();

            foreach (var type in _projectTypes)
            {
                type.SelectDefault();
            }
        }

        public ProjectType CurrentProjectType
        {
            get {
                return currentProjectType;
            }
        }

        public Properties ESInterfaceProject
        {
            get
            {
                return _properties;
            }
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {
            foreach (var projType in _projectTypes)
            {
                projectType.Items.Add(projType);
            }

            Reset(_projectTypes[0]);

            projectType.SelectedIndex = 0;

            foreach (var nuget in _nugetItemPackages)
            {
                CheckState check = CheckState.Unchecked;

                if (nuget.Default)
                {
                    check = CheckState.Checked;
                }

                nugetPackages.Items.Add(nuget, check);
            }
        }

        private void Reset(ProjectType type)
        {
            thisProject = new WorksProject()
            {
                ProjectName = "",
                ProjectType = ProjectTypeEnum.WebApi,
                SelectedTemplate = _projectTypes[0].SelectedTemplate,// ((ProjectType)projectType.SelectedItem).SelectedTemplate,
                TemplateFilename = _projectTypes[0].SelectedTemplate.TemplateFilename//((ProjectType)projectType.SelectedItem).SelectedTemplate.TemplateFilename
            };

            webApiPanel.Reset();
            mvcView.Reset();
            angularView.Reset();

            thisProject.Extension = null;
            thisProject.SelectedTemplate = type.SelectedTemplate;

            switch (type.Type)
            {
                case ProjectTypeEnum.WebApi:
                    webApiPanel.Init(this, thisProject);
                    webApiPanel.Visible = true;
                    break;
                case ProjectTypeEnum.ServiceLibrary:
                    servicePanel.Visible = true;
                    break;
                case ProjectTypeEnum.DataLayer:
                    dataPanel.Visible = true;
                    break;
                case ProjectTypeEnum.MVCWebsite:
                    mvcView.Init(this, thisProject);
                    mvcView.Visible = true;
                    break;
                case ProjectTypeEnum.AngularWebsite:
                    angularView.Init(this, thisProject);
                    angularView.Visible = true;
                    break;
            }
        }

        private void projectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectType projType = (ProjectType)((ComboBox)sender).SelectedItem;
            projType.SelectDefault();

            webApiPanel.Visible = false;
            servicePanel.Visible = false;
            dataPanel.Visible = false;
            angularView.Visible = false;
            mvcView.Visible = false;

            selectedType = projType.Type;
            currentProjectType = projType;

            Reset(projType);
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newProject_Click(object sender, EventArgs e)
        {
            editing = false;

            newProject.Enabled = false;

            projectName.Enabled = true;
            projectType.Enabled = true;

            saveProject.Enabled = true;
            cancelProject.Enabled = true;

            editProject.Enabled = false;
            deleteProject.Enabled = false;

            nugetPackages.Enabled = true;

            try
            {
                int pos = 0;
                foreach (var checkNuget in _nugetItemPackages)
                {
                    nugetPackages.SetItemChecked(pos++, checkNuget.Default);
                }

                Reset(_projectTypes[0]);

                webApiPanel.Enabled = true;
                mvcView.Enabled = true;
                angularView.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveProject_Click(object sender, EventArgs e)
        {
            ProjectType projType = (ProjectType)projectType.SelectedItem;

            if (!editing)
            {
                foreach (var nugetCheck in nugetPackages.CheckedItems)
                {
                    ProjectNuget nuget = (ProjectNuget)nugetCheck;
                    thisProject.Nugets.Add(nuget);
                }

                _properties.Projects.Add(thisProject);
                thisProject.ProjectName = projectName.Text;

                ProjectTemplate pType = null;

                switch (projType.Type)
                {
                    case ProjectTypeEnum.WebApi:
                        pType = webApiPanel.SelectedTemplate;
                        break;
                    case ProjectTypeEnum.MVCWebsite:
                        pType = mvcView.SelectedTemplate;
                        break;
                    case ProjectTypeEnum.AngularWebsite:
                        pType = angularView.SelectedTemplate;
                        break;
                }

                thisProject.ProjectType = projType.Type;
                thisProject.SelectedTemplate = pType;
                thisProject.TemplateFilename = pType.TemplateFilename;

                var node = projectTree.Nodes[0].Nodes.Add(projectName.Text);
                node.Tag = thisProject;
            }
            else
            {
                var project = (WorksProject)projectTree.SelectedNode.Tag;
                project.ProjectName = projectName.Text;
                
                project.Nugets.Clear();

                foreach (var nugetCheck in nugetPackages.CheckedItems)
                {
                    ProjectNuget nuget = (ProjectNuget)nugetCheck;
                    project.Nugets.Add(nuget);
                }

                ProjectTemplate pType = null;

                switch (projType.Type)
                {
                    case ProjectTypeEnum.WebApi:
                        pType = webApiPanel.SelectedTemplate;
                        break;
                    case ProjectTypeEnum.MVCWebsite:
                        pType = mvcView.SelectedTemplate;
                        break;
                    case ProjectTypeEnum.AngularWebsite:
                        pType = angularView.SelectedTemplate;
                        break;
                }

                project.ProjectType = projType.Type;
                project.SelectedTemplate = pType;
                project.TemplateFilename = pType.TemplateFilename;
            }

            newProject.Enabled = true;

            projectName.Text = "";

            Reset(_projectTypes[0]);

            projectType.SelectedIndex = 0;

            projectName.Enabled = false;
            projectType.Enabled = false;

            saveProject.Enabled = false;
            cancelProject.Enabled = false;
            nugetPackages.Enabled = false;

            newProject.Enabled = true;
            editProject.Enabled = false;
            deleteProject.Enabled = false;

            projectTree.Enabled = true;

            int pos = 0;
            foreach (var checkNuget in _nugetItemPackages)
            {
                nugetPackages.SetItemChecked(pos++, checkNuget.Default);
            }

            webApiPanel.Enabled = false;
            mvcView.Enabled = false;
            angularView.Enabled = false;
        }

        private void projectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void editProject_Click(object sender, EventArgs e)
        {
            newProject.Enabled = false;
            editProject.Enabled = false;
            deleteProject.Enabled = false;

            projectName.Enabled = true;
            projectType.Enabled = true;

            saveProject.Enabled = true;
            cancelProject.Enabled = true;
            nugetPackages.Enabled = true;

            projectTree.Enabled = false;

            editing = true;

            try
            {
                var project = (WorksProject)projectTree.SelectedNode.Tag;
                projectName.Text = project.ProjectName;
                projectType.SelectedIndex = (int)project.ProjectType;

                List<bool> checkThem = new List<bool>();

                foreach (var checkNuget in nugetPackages.Items)
                {
                    ProjectNuget check = (ProjectNuget)checkNuget;
                    ProjectNuget item = project.Nugets.Where(x => x.Name == check.Name).FirstOrDefault();

                    if (item != null)
                    {
                        checkThem.Add(true);
                    }
                    else
                    {
                        checkThem.Add(false);
                    }
                }

                int pos = 0;
                foreach (var docheck in checkThem)
                {
                    nugetPackages.SetItemChecked(pos++, docheck);
                }

                switch (project.ProjectType)
                {
                    case ProjectTypeEnum.WebApi:
                        webApiPanel.Init(this, project);

                        WebApiExtension ext = (WebApiExtension)project.Extension;

                        webApiPanel.Enabled = true;
                        break;
                    case ProjectTypeEnum.MVCWebsite:
                        mvcView.Init(this, project);
                        mvcView.Enabled = true;
                        break;
                    case ProjectTypeEnum.AngularWebsite:
                        angularView.Init(this, project);
                        angularView.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelProject_Click(object sender, EventArgs e)
        {
            newProject.Enabled = true;

            projectName.Text = "";
            projectType.SelectedIndex = 0;

            Reset(_projectTypes[0]);

            projectName.Enabled = false;
            projectType.Enabled = false;

            saveProject.Enabled = false;
            cancelProject.Enabled = false;
            nugetPackages.Enabled = false;

            newProject.Enabled = true;
            editProject.Enabled = false;
            deleteProject.Enabled = false;

            projectTree.Enabled = true;

            int pos = 0;
            foreach (var checkNuget in _nugetItemPackages)
            {
                nugetPackages.SetItemChecked(pos++, checkNuget.Default);
            }

            webApiPanel.Reset();
            webApiPanel.Enabled = false;

            mvcView.Reset();
            mvcView.Enabled = false;

            angularView.Reset();
            angularView.Enabled = false;
        }

        private void projectTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string root = e.Node.Tag as string;

            if (root == null)
            {
                newProject.Enabled = true;
                editProject.Enabled = true;
                deleteProject.Enabled = true;
            }
        }

        private void cancelAll_Click(object sender, EventArgs e)
        {
            _properties.Cancel = true;

            this.Close();
        }
    }
}
