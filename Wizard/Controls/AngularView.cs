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

namespace Wizard.Controls
{
    public partial class AngularView : UserControl
    {
        WizardForm _form;
        WorksProject _project;

        ProjectTemplate _template;

        public ProjectTemplate SelectedTemplate
        {
            get
            {
                return _template;
            }
        }

        public AngularView()
        {
            InitializeComponent();
        }

        private void authentication_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void Init(WizardForm form, WorksProject project)
        {
            _form = form;
            _project = project;

            if (_project.SelectedTemplate.Name == "Authenticated Angular Web Site")
            {
                authenticationDropdown.SelectedIndex = 2;
            }
            else if (_project.SelectedTemplate.Name == "Angular Web Site")
            {
                authenticationDropdown.SelectedIndex = 0;
            }
            else
            {
                authenticationDropdown.SelectedIndex = 1;
            }
        }

        public void Reset()
        {
            //authenticationDropdown.SelectedIndex = 0;
        }

        private void authenticationDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authenticationDropdown.SelectedIndex == 2)
            {
                //_project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Authenticated Angular Web Site").First();
                //_project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
                _template = _form.CurrentProjectType.Templates.Where(x => x.Name == "Authenticated Angular Web Site").First();
                _template.TemplateFilename = _template.TemplateFilename;
            }
            else if (authenticationDropdown.SelectedIndex == 0)
            {
                //_project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Angular Web Site").First();
                //_project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
                _template = _form.CurrentProjectType.Templates.Where(x => x.Name == "Angular Web Site").First();
                _template.TemplateFilename = _template.TemplateFilename;
            }
            else
            {
                //_project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Windows Auth Angular Web Site").First();
                //_project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
                _template = _form.CurrentProjectType.Templates.Where(x => x.Name == "Windows Auth Angular Web Site").First();
                _template.TemplateFilename = _template.TemplateFilename;
            }
        }
    }
}
