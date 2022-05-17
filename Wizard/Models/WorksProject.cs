using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizard.Models.Extensions;

namespace Wizard.Models
{
    public class WorksProject
    {
        public string ProjectName { get; set; }
        public ProjectTypeEnum ProjectType { get; set; }

        public ProjectTemplate SelectedTemplate { get; set; }

        public string TemplateFilename { get; set; }

        public List<ProjectNuget> Nugets { get; set; } = new List<ProjectNuget>();

        public BaseExtension Extension { get; set; }
    }
}
