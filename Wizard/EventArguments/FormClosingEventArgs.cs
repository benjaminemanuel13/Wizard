using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.EventArguments
{
    public class FormClosingEventArgs : EventArgs
    {
        public string Message { get; set; }

        public FormClosingEventArgs(string message)
        {
            Message = message;
        }
    }
}
