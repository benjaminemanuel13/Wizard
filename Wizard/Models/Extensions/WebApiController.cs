using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.Models.Extensions
{
    public class WebApiController
    {
        public string Name { get; set; }

        public List<WebApiEndpoint> Endpoints { get; set; } = new List<WebApiEndpoint>();

        public override string ToString()
        {
            return Name;
        }
    }
}
