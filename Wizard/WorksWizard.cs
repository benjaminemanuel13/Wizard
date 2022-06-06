using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                }

                foreach (Project proj in dte.DTE.Solution.Projects)
                {
                    
                    if (proj.Name == project.ProjectName)
                    {
                        string filepath = proj.FullName;
                        string projPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1);

                        Solution2 sol = dte.DTE.Solution as Solution2;
                        switch (project.ProjectType)
                        {
                            case Models.ProjectTypeEnum.WebApi:
                                WebApiExtension apiext = project.Extension as WebApiExtension;

                                for (int i = 1; i <= proj.ProjectItems.Count; i++)
                                {
                                    var item = proj.ProjectItems.Item(i);

                                    if (item.Name == "Controllers" && project.SelectedTemplate.Name == "Web Api")
                                    {
                                        foreach (var controller in apiext.Controllers)
                                        {
                                            AddItem(item, controller.Name, "WorksApiController.zip");
                                        }

                                        foreach (var controller in apiext.Controllers)
                                        {
                                            StringBuilder builder = new StringBuilder();

                                            foreach (var endpoint in controller.Endpoints)
                                            {
                                                StringBuilder endBuilder = new StringBuilder();

                                                endBuilder.AppendLine("\t\t[Http####(\"####" + endpoint.Name + "\")]");
                                                endBuilder.AppendLine("\t\tpublic ##RETURN## ####" + endpoint.Name + "(##PARAMS###)");
                                                endBuilder.AppendLine("\t\t{");
                                                endBuilder.AppendLine("\t\t\t##RETVALUE##");
                                                endBuilder.AppendLine("\t\t}");
                                                endBuilder.AppendLine("\t\t");

                                                string method = endBuilder.ToString();

                                                StringBuilder subBuild = new StringBuilder();

                                                if (endpoint.Get)
                                                {
                                                    subBuild.Append(method.Replace("####", "Get").Replace("##RETVALUE##", "return null;").Replace("##RETURN##", "object").Replace("##PARAMS###", ""));
                                                }
                                                if (endpoint.Post)
                                                {
                                                    subBuild.Append(method.Replace("####", "Post").Replace("##RETVALUE##", "").Replace("##RETURN##", "void").Replace("##PARAMS###", "object obj"));
                                                }
                                                if (endpoint.Put)
                                                {
                                                    subBuild.Append(method.Replace("####", "Put").Replace("##RETVALUE##", "").Replace("##RETURN##", "void").Replace("##PARAMS###", "int id, object obj"));
                                                }
                                                if (endpoint.Delete)
                                                {
                                                    subBuild.Append(method.Replace("####", "Delete").Replace("##RETVALUE##", "").Replace("##RETURN##", "void").Replace("##PARAMS###", "int id"));
                                                }

                                                string endpointCode = subBuild.ToString();
                                                builder.Append(endpointCode);
                                            }

                                            ProjectItem newItem = null;
                                            foreach (ProjectItem it in item.ProjectItems)
                                            {
                                                if (it.Name == controller.Name + ".cs")
                                                {
                                                    newItem = it;
                                                    break;
                                                }
                                            }

                                            string itemPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1) + "\\Controllers\\" + newItem.Name;

                                            FileStream stream = File.Open(itemPath, FileMode.Open);
                                            StreamReader reader = new StreamReader(stream);

                                            string text = reader.ReadToEnd();
                                            text = text.Replace("##ENDPOINTS##", builder.ToString());

                                            reader.Close();
                                            stream.Close();

                                            stream = File.Open(itemPath, FileMode.Open);
                                            StreamWriter writer = new StreamWriter(stream);
                                            writer.WriteLine(text);

                                            writer.Close();
                                            stream.Close();
                                        }
                                    }
                                    else if (item.Name == "Release.yml")
                                    {
                                        string itemPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1) + "\\Release.yml";

                                        FileStream stream = File.Open(itemPath, FileMode.Open);
                                        StreamReader reader = new StreamReader(stream);

                                        string text = reader.ReadToEnd();
                                        text = text.Replace("###PROJECTNAME###", project.ProjectName);

                                        reader.Close();
                                        stream.Close();

                                        stream = File.Open(itemPath, FileMode.Open);
                                        StreamWriter writer = new StreamWriter(stream);
                                        writer.WriteLine(text);

                                        writer.Close();
                                        stream.Close();
                                    }
                                    else if (item.Name == "Program.cs" && project.SelectedTemplate.Name == "Minimal Web Api")
                                    {
                                        foreach (var controller in apiext.Controllers)
                                        {
                                            StringBuilder builder = new StringBuilder();

                                            foreach (var endpoint in controller.Endpoints)
                                            {
                                                StringBuilder endBuilder = new StringBuilder();

                                                endBuilder.AppendLine("app.Map####(\"/" + endpoint.Name.ToLower() + "##ARGS##\", (##PARAMS##) =>");
                                                endBuilder.AppendLine("{");
                                                endBuilder.AppendLine("\t##RETVALUE##");
                                                endBuilder.AppendLine("}).WithName(\"####" + endpoint.Name + "\");");
                                                endBuilder.AppendLine("");

                                                string method = endBuilder.ToString();

                                                StringBuilder subBuild = new StringBuilder();

                                                if (endpoint.Get)
                                                {
                                                    subBuild.Append(method.Replace("####", "Get").Replace("##RETVALUE##", "return new object();").Replace("##ARGS##", "/{id}").Replace("##PARAMS##", "[FromRoute] int id"));
                                                }
                                                if (endpoint.Post)
                                                {
                                                    subBuild.Append(method.Replace("####", "Post").Replace("##RETVALUE##", "").Replace("##ARGS##", "").Replace("##PARAMS##", "object obj"));
                                                }
                                                if (endpoint.Put)
                                                {
                                                    subBuild.Append(method.Replace("####", "Put").Replace("##RETVALUE##", "").Replace("##ARGS##", "/{id}").Replace("##PARAMS##", "[FromRoute] int id, object obj"));
                                                }
                                                if (endpoint.Delete)
                                                {
                                                    subBuild.Append(method.Replace("####", "Delete").Replace("##RETVALUE##", "").Replace("##ARGS##", "/{id}").Replace("##PARAMS##", "[FromRoute] int id"));
                                                }

                                                string endpointCode = subBuild.ToString();
                                                builder.Append(endpointCode);
                                            }

                                            string itemPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1) + "\\Program.cs";

                                            FileStream stream = File.Open(itemPath, FileMode.Open);
                                            StreamReader reader = new StreamReader(stream);

                                            string text = reader.ReadToEnd();
                                            text = text.Replace("##ENDPOINTS##", builder.ToString());

                                            reader.Close();
                                            stream.Close();

                                            stream = File.Open(itemPath, FileMode.Open);
                                            StreamWriter writer = new StreamWriter(stream);
                                            writer.WriteLine(text);

                                            writer.Close();
                                            stream.Close();
                                        }
                                    }
                                }
                                break;
                            case Models.ProjectTypeEnum.MVCWebsite:
                                MVCExtension mvcext = project.Extension as MVCExtension;

                                for (int i = 1; i <= proj.ProjectItems.Count; i++)
                                {
                                    var item = proj.ProjectItems.Item(i);

                                    if (item.Name == "Controllers")
                                    {
                                        foreach (var controller in mvcext.Controllers)
                                        {
                                            AddItem(item, controller.Name, "WorksMvcController.zip");
                                        }

                                        foreach (var controller in mvcext.Controllers)
                                        {
                                            StringBuilder builder = new StringBuilder();

                                            foreach (var endpoint in controller.Endpoints)
                                            {
                                                StringBuilder endBuilder = new StringBuilder();

                                                endBuilder.AppendLine("\t\t##HTTP##");
                                                endBuilder.AppendLine("\t\tpublic IActionResult " + endpoint.Name + "(##PARAMS###)");
                                                endBuilder.AppendLine("\t\t{");
                                                endBuilder.AppendLine("\t\t\t##RETVALUE##");
                                                endBuilder.AppendLine("\t\t}");
                                                endBuilder.AppendLine("\t\t");

                                                string method = endBuilder.ToString();

                                                StringBuilder subBuild = new StringBuilder();

                                                if (endpoint.Get)
                                                {
                                                    subBuild.Append(method.Replace("##HTTP##", "").Replace("##RETVALUE##", "return View();").Replace("##PARAMS###", ""));
                                                }
                                                if (endpoint.Post)
                                                {
                                                    subBuild.Append(method.Replace("##HTTP##", "[HttpPost]").Replace("##RETVALUE##", "").Replace("##PARAMS###", "object obj"));
                                                }
                                                if (endpoint.Put)
                                                {
                                                    subBuild.Append(method.Replace("##HTTP##", "[HttpPut]").Replace("##RETVALUE##", "").Replace("##PARAMS###", "int id, object obj"));
                                                }
                                                if (endpoint.Delete)
                                                {
                                                    subBuild.Append(method.Replace("##HTTP##", "[HttpDelete]").Replace("##RETVALUE##", "").Replace("##PARAMS###", "int id"));
                                                }

                                                string endpointCode = subBuild.ToString();
                                                builder.Append(endpointCode);
                                            }

                                            ProjectItem newItem = null;
                                            foreach (ProjectItem it in item.ProjectItems)
                                            {
                                                if (it.Name == controller.Name + ".cs")
                                                {
                                                    newItem = it;
                                                    break;
                                                }
                                            }

                                            string itemPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1) + "\\Controllers\\" + newItem.Name;

                                            FileStream stream = File.Open(itemPath, FileMode.Open);
                                            StreamReader reader = new StreamReader(stream);

                                            string text = reader.ReadToEnd();
                                            text = text.Replace("###VIEWS###", builder.ToString()).Replace("##PROJECTNAME##", proj.Name);

                                            reader.Close();
                                            stream.Close();

                                            stream = File.Open(itemPath, FileMode.Open);
                                            StreamWriter writer = new StreamWriter(stream);
                                            writer.WriteLine(text);

                                            writer.Close();
                                            stream.Close();
                                        }
                                    }
                                    else if (item.Name == "Views" && (project.SelectedTemplate.Name == "MVC Web Site" || project.SelectedTemplate.Name == "Authenticated MVC Web Site"))
                                    {
                                        foreach (var controller in mvcext.Controllers)
                                        {
                                            //Not sure what will happen if controller name doesn't end with "Controller" (Asp.Net expects that to match with Views folder)
                                            var shortName = controller.Name.EndsWith("Controller") ? controller.Name.Substring(0, controller.Name.Length - 10) : controller.Name;

                                            try
                                            {
                                                //This throws a Null exception, however it works...?  The new folder is available.
                                                item.ProjectItems.AddFolder(shortName);
                                            }
                                            catch { }

                                            ProjectItem folder = null;
                                            foreach (var it in item.ProjectItems)
                                            {
                                                ProjectItem temp = it as ProjectItem;

                                                if (temp == null)
                                                {
                                                    MessageBox.Show("Null");
                                                }

                                                if (temp.Name == shortName)
                                                {
                                                    folder = temp;
                                                    break;
                                                }
                                            }

                                            foreach (var endpoint in controller.Endpoints)
                                            {
                                                //Create Views
                                                AddItem(folder, endpoint.Name, "WorksMvcView.zip", "cshtml");
                                            }
                                        }
                                    }
                                    else if (item.Name == "Release.yml")
                                    {
                                        string itemPath = proj.FullName.Substring(0, proj.FullName.LastIndexOf("\\") + 1) + "\\Release.yml";

                                        FileStream stream = File.Open(itemPath, FileMode.Open);
                                        StreamReader reader = new StreamReader(stream);

                                        string text = reader.ReadToEnd();
                                        text = text.Replace("###PROJECTNAME###", project.ProjectName);

                                        reader.Close();
                                        stream.Close();

                                        stream = File.Open(itemPath, FileMode.Open);
                                        StreamWriter writer = new StreamWriter(stream);
                                        writer.WriteLine(text);

                                        writer.Close();
                                        stream.Close();
                                    }
                                }

                                break;
                            case Models.ProjectTypeEnum.AngularWebsite:
                                
                                break;
                            }
                        }
                    }
                }
                var projMain = dte.DTE.Solution.Projects.Item(1);
            dte.DTE.Solution.Remove(projMain);
        }

        private void AddItem(ProjectItem project, string itemName, string templateFilename, string extension = "cs")
        {
            Solution2 sol = (Solution2)dte.DTE.Solution;

            try
            {
                string templatePath = sol.GetProjectItemTemplate(templateFilename, "CSharp");
                project.ProjectItems.AddFromTemplate(templatePath, itemName + "." + extension);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
