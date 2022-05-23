using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wizard.Forms;
using Wizard.Models;
using Wizard.Models.Extensions;

namespace Wizard.Controls
{
    public partial class MVCView : UserControl
    {
        WizardForm _form;
        WorksProject _project;

        ControllerForm _conForm;

        MVCExtension _ext;
        MVCController _current;

        ProjectTemplate _template;

        public ProjectTemplate SelectedTemplate
        {
            get
            {
                return _template;
            }
        }

        public MVCExtension Extension
        {
            get
            {
                return _ext;
            }
        }

        public bool SubCancelled { get; set; } = false;

        public MVCView()
        {
            InitializeComponent();
        }

        private void authentication_CheckedChanged(object sender, EventArgs e)
        {
            if (authentication.Checked)
            {
                //_project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "Authenticated MVC Web Site").First();
                //_project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;

                _template = _form.CurrentProjectType.Templates.Where(x => x.Name == "Authenticated MVC Web Site").First();
                _template.TemplateFilename = _template.TemplateFilename;
            }
            else
            {
                //_project.SelectedTemplate = _form.CurrentProjectType.Templates.Where(x => x.Name == "MVC Web Site").First();
                //_project.TemplateFilename = _project.SelectedTemplate.TemplateFilename;
                _template = _form.CurrentProjectType.Templates.Where(x => x.Name == "MVC Web Site").First();
                _template.TemplateFilename = _template.TemplateFilename;
            }
        }

        public void Init(WizardForm form, WorksProject project)
        {
            _form = form;
            _project = project;

            if (project.Extension == null)
            {
                project.Extension = new MVCExtension();
            }

            _ext = project.Extension as MVCExtension;

            if (_project.SelectedTemplate.Name == "Authenticated MVC Web Site")
            {
                authentication.Checked = true;
            }
            else
            {
                authentication.Checked = false;
            }

            controllers.Items.Clear();

            foreach (var controller in _ext.Controllers)
            {
                controllers.Items.Add(controller);
            }
        }

        public void Reset()
        {
            authentication.Checked = false;
        }

        private void add_Click(object sender, EventArgs e)
        {
            MVCController controller = new MVCController();

            _conForm = new ControllerForm(controller, this);
            _conForm.ShowDialog();

            if (!SubCancelled)
            {
                try
                {
                    controllers.Items.Add(controller);
                    _ext.Controllers.Add(controller);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            _conForm = new ControllerForm(_current, this);
            _conForm.ShowDialog();

            if (!SubCancelled)
            {

            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

        }

        private void controllers_SelectedIndexChanged(object sender, EventArgs e)
        {
            MVCController controller = controllers.SelectedItem as MVCController;

            if (controller == null)
            {
                return;
            }

            _current = controller;

            add.Enabled = true;
            edit.Enabled = true;
            delete.Enabled = true;
        }
    }
}
