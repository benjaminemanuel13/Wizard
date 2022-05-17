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

namespace Wizard.Controls
{
    public partial class WebApiView : UserControl
    {
        WizardForm _form;
        WorksProject _project;

        WebApiExtension _ext;

        public WebApiView()
        {
            InitializeComponent();
        }

        private void WebApiView_Load(object sender, EventArgs e)
        {

        }

        public void Init(WizardForm form, WorksProject project)
        { 
            _form = form;
            _project = project;

            if (project.Extension == null)
            {
                project.Extension = new WebApiExtension();
            }

            _ext = project.Extension as WebApiExtension;

            if (_project.SelectedTemplate.Name == "Minimal Web Api")
            {
                minimal.Checked = true;
            }
            else
            {
                minimal.Checked = false;
            }

            controllers.Items.Clear();

            foreach (var controller in _ext.Controllers)
            {
                controllers.Items.Add(controller);
            }
        }

        public void Reset()
        {
            minimal.Checked = false;
        }

        private void minimal_CheckedChanged(object sender, EventArgs e)
        {
            if (minimal.Checked)
            {
                _project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Minimal Web Api").First();
                _project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
            }
            else
            {
                _project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Web Api").First();
                _project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            
        }

        private void edit_Click(object sender, EventArgs e)
        {

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void controllers_SelectedIndexChanged(object sender, EventArgs e)
        {
            WebApiController controller = (WebApiController)sender;

            add.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;
        }
    }
}
