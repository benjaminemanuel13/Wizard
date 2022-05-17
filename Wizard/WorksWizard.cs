using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Wizard.Helpers;
using Wizard.Models.Extensions;

namespace Wizard
{
    public class WorksWizard : IWizard
    {
        private EnvDTE80.DTE2 dte;
        private WizardForm _form;
        string solutionPath, projectPath;
        private string message = "";

        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            //throw new NotImplementedException();
        }

        public void ProjectFinishedGenerating(Project project)
        {
            //throw new NotImplementedException();
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            //throw new NotImplementedException();
        }

        public void RunFinished()
        {
            solutionPath = System.IO.Path.GetDirectoryName(dte.DTE.Solution.FullName);
            projectPath = System.IO.Path.GetDirectoryName(dte.DTE.FullName);

            NugetHelper nuHelper = new NugetHelper();

            foreach (var project in _form.ESInterfaceProject.Projects)
            {
                MessageBox.Show(project.ProjectName);

                AddProject(solutionPath, project.ProjectName, project.TemplateFilename);

                foreach (var nuget in project.Nugets)
                {
                    //Add Nuget Package to Project
                    nuHelper.AddNuget(nuget.Name, nuget.Version, "net6.0", solutionPath);

                    foreach (Project proj in dte.DTE.Solution.Projects)
                    {
                        if (proj.Name == project.ProjectName)
                        {
                            string filepath = proj.FullName;
                            string projPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1);

                            Solution2 sol = dte.DTE.Solution as Solution2;

                            try
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.Load(filepath);

                                bool found = false;

                                foreach (var node in doc.ChildNodes[0].ChildNodes)
                                {
                                    XmlNode thisNode = (XmlNode)node;
                                    if (thisNode.Name == "ItemGroup")
                                    {
                                        if (thisNode.ChildNodes[0].Name == "PackageReference")
                                        {
                                            found = true;
                                            XmlNode newNode = doc.CreateElement("PackageReference");
                                            XmlAttribute att1 = doc.CreateAttribute("Include");
                                            att1.Value = nuget.Name;

                                            XmlAttribute att2 = doc.CreateAttribute("Version");
                                            att2.Value = nuget.Version;

                                            newNode.Attributes.Append(att1);
                                            newNode.Attributes.Append(att2);
                                            thisNode.AppendChild(newNode);

                                            break;
                                        }
                                    }
                                }

                                if (!found)
                                {
                                    //Add ItemGroup with PackageReference and current NuGet.
                                    XmlNode itemGroupNode = doc.CreateElement("ItemGroup");
                                    XmlNode packageNode = doc.CreateElement("PackageReference");

                                    XmlAttribute att1 = doc.CreateAttribute("Include");
                                    att1.Value = nuget.Name;

                                    XmlAttribute att2 = doc.CreateAttribute("Version");
                                    att2.Value = nuget.Version;

                                    packageNode.Attributes.Append(att1);
                                    packageNode.Attributes.Append(att2);

                                    itemGroupNode.AppendChild(packageNode);
                                    doc.ChildNodes[0].AppendChild(itemGroupNode);
                                }

                                doc.Save(filepath);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            break;
                        }
                    }

                    try
                    {
                        //dte.DTE.ExecuteCommand("Build.BuildSolution");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Build: " + ex.Message);
                    }
                    //Project proj = dte.DTE.Solution.Projects.Item(pos++);
                }

                switch (project.ProjectType)
                {
                    case Models.ProjectTypeEnum.WebApi:
                        WebApiExtension ext = project.Extension as WebApiExtension; 
                        break;
                }
            }

            var projMain = dte.DTE.Solution.Projects.Item(1);
            dte.DTE.Solution.Remove(projMain);

            //var basePath = projMain.FullName.Substring(0, projMain.FullName.LastIndexOf("\\") + 1);
            //var nugetPath = basePath + "nuget.config";

            //File.Move(nugetPath, solutionPath + "\\" + "nuget.config");
        }

        private void AddProject(string solutionPath, string projectName, string templateFilename)
        {
            string projectPath = solutionPath + @"\" + projectName + @"\";

            if (!Directory.Exists(projectPath))
            {
                Directory.CreateDirectory(projectPath);
            }

            Solution2 sol = (Solution2)dte.DTE.Solution;

            try
            {
                string templatePath = sol.GetProjectTemplate(templateFilename, "CSharp");
                dte.DTE.Solution.AddFromTemplate(templatePath, projectPath, projectName, false);

                var path = dte.DTE.Solution.FullName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            _form = new WizardForm();
            _form.FormClosing += _form_FormClosing;

            _form.ShowDialog();

            if (_form.ESInterfaceProject.Cancel)
            {
                Application.ExitThread();

                return;
            }

            dte = automationObject as EnvDTE80.DTE2;
            
            replacementsDictionary.Add("$message$", message);
        }

        private void _form_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //message = _form.ESInterfaceProject.ProjectName;
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
