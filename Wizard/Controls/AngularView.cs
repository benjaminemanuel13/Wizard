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

        public AngularView()
        {
            InitializeComponent();
        }

        private void authentication_CheckedChanged(object sender, EventArgs e)
        {
            if (authentication.Checked)
            {
                _project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Authenticated Angular Web Site").First();
                _project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
            }
            else
            {
                _project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Angular Web Site").First();
                _project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
            }
        }

        public void Init(WizardForm form, WorksProject project)
        {
            _form = form;
            _project = project;

            if (_project.SelectedTemplate.Name == "Authenticated Angular Web Site")
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
