using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wizard.Controls;
using Wizard.Models.Extensions;

namespace Wizard.Forms
{
    public partial class ControllerForm : Form
    {
        private UserControl _parent;
        private WorksControllerBase _controller;
        private WebApiEndpoint _endpoint;

        private bool editing = false;

        public bool Editing { get; set; } = false;

        public ControllerForm(WorksControllerBase controller, UserControl parent)
        {
            InitializeComponent();

            _controller = controller;
            _parent = parent;

            if(string.IsNullOrEmpty(controller.Name))
            {
                name.Text = "ValuesController";
                name.Select(0, 6);
            }
            else
                name.Text = controller.Name;

            foreach (var endpoint in _controller.Endpoints)
            {
                methods.Items.Add(endpoint);
            }
        }

        private void addMethod_Click(object sender, EventArgs e)
        {
            editing = false;

            method.Enabled = true;
        }

        private void editMethod_Click(object sender, EventArgs e)
        {
            editing = true;

            methodName.Text = _endpoint.Name;
            getMethod.Checked = _endpoint.Get;
            postMethod.Checked = _endpoint.Post;
            putMethod.Checked = _endpoint.Put;
            deleteMethod.Checked = _endpoint.Delete;

            method.Enabled = true;
        }

        private void deleteThisMethod_Click(object sender, EventArgs e)
        {

        }

        private void saveMethod_Click(object sender, EventArgs e)
        {
            if (!editing)
            {
                WebApiEndpoint endpoint = new WebApiEndpoint()
                {
                    Name = methodName.Text,
                    Get = getMethod.Checked,
                    Post = postMethod.Checked,
                    Put = putMethod.Checked,
                    Delete = deleteMethod.Checked
                };

                _controller.Endpoints.Add(endpoint);

                methods.Items.Add(endpoint);
            }
            else
            {
                _endpoint.Name = methodName.Text;
                _endpoint.Get = getMethod.Checked;
                _endpoint.Post = postMethod.Checked;
                _endpoint.Put = putMethod.Checked;
                _endpoint.Delete = deleteMethod.Checked;
            }

            addMethod.Enabled = true;
            editMethod.Enabled = false;
            deleteThisMethod.Enabled = false;

            method.Enabled = false;

            ResetMethods();
        }

        private void methods_SelectedIndexChanged(object sender, EventArgs e)
        {
            _endpoint = (WebApiEndpoint)methods.SelectedItem;

            addMethod.Enabled = true;
            editMethod.Enabled = true;
            deleteThisMethod.Enabled = true;

            ResetMethods();
        }

        private void ResetMethods()
        {
            methodName.Text = "";
            getMethod.Checked = false;
            postMethod.Checked = false;
            putMethod.Checked = false;
            deleteMethod.Checked = false;

            method.Enabled = false;
        }

        private void cancelMethod_Click(object sender, EventArgs e)
        {
            ResetMethods();
        }

        private void save_Click(object sender, EventArgs e)
        {
            _controller.Name = name.Text;

            if (_parent is WebApiView)
            {
                ((WebApiView)_parent).SubCancelled = false;
            }
            else if (_parent is MVCView)
            {
                ((MVCView)_parent).SubCancelled = false;
            }

            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (_parent is WebApiView)
            {
                ((WebApiView)_parent).SubCancelled = true;
            }
            else if (_parent is MVCView)
            {
                ((MVCView)_parent).SubCancelled = true;
            }

            this.Close();
        }

        private void ControllerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
