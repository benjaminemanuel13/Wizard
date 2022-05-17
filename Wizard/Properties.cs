using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizard.Models;

namespace Wizard
{
    public class Properties
    {
        public string SolutionName { get; set; }

        public List<WorksProject> Projects { get; set; } = new List<WorksProject>();

        public bool Cancel { get; set; } = false;
    }
}
