using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.Models.Extensions
{
    public class MVCExtension : BaseExtension
    {
        public List<MVCController> Controllers { get; set; } = new List<MVCController>();
    }
}
