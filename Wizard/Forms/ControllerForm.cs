using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wizard.Models.Extensions;

namespace Wizard.Forms
{
    public partial class ControllerForm : Form
    {
        private readonly WebApiController _controller;
        public ControllerForm(WebApiController controller)
        {
            InitializeComponent();

            _controller = controller;

            name.Text = controller.Name;

            foreach (var endpoint in _controller.Endpoints)
            {
                methods.Items.Add(endpoint);
            }
        }
    }
}
