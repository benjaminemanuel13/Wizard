using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.Models.Extensions
{
    public class WebApiExtension : BaseExtension
    {
        public List<WebApiController> Controllers { get; set; } = new List<WebApiController>();
    }
}
