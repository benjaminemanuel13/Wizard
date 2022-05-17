using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.Models
{
    public class ProjectNuget
    {
        public string DisplayName { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public bool Default { get; set; } = false;

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
