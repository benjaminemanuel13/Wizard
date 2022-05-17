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
    public partial class MVCView : UserControl
    {
        WizardForm _form;
        WorksProject _project;

        public MVCView()
        {
            InitializeComponent();
        }

        private void authentication_CheckedChanged(object sender, EventArgs e)
        {
            if (authentication.Checked)
            {
                _project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Authenticated MVC Web Site").First();
                _project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
            }
            else
            {
                _project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "MVC Web Site").First();
                _project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
            }
        }

        public void Init(WizardForm form, WorksProject project)
        {
            _form = form;
            _project = project;

            if (_project.SelectedTemplate.Name == "Authenticated MVC Web Site")
            {
                authentication.Checked = true;
            }
            else
            {
                authentication.Checked = false;
            }
        }

        public void Reset()
        {
            authentication.Checked = false;
        }
    }
}
