using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizard.Models
{
    public enum ProjectTypeEnum
    { 
        WebApi,
        ServiceLibrary,
        DataLayer,
        Console,
        MVCWebsite,
        AngularWebsite
    }

    public class ProjectType
    {
        public string Name { get; set; }

        public void SelectDefault()
        {
            SelectedTemplate = Templates.First();
        }

        public ProjectTemplate SelectedTemplate { get; set; }

        public List<ProjectTemplate> Templates { get; set; } = new List<ProjectTemplate>();

        public ProjectTypeEnum Type { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
