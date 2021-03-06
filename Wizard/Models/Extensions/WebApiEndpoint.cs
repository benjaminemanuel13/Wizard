using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.Models.Extensions
{
    public class WebApiEndpoint
    {
        public string Name { get; set; }

        public bool Get { get; set; }
        public bool Post { get; set; }
        public bool Put { get; set; }
        public bool Delete { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
