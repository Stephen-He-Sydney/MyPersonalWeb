using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class Project
    {
        public Project()
        {
            this.ProjectDuties = new HashSet<ProjectDuty>();
            this.ProjectTechniques = new HashSet<ProjectTechnique>();
        }

        [Key]
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Language { get; set; }
        public string DevelopmentTool { get; set; }
        public int ProjectTypeID { get; set; }
    
        public virtual ICollection<ProjectDuty> ProjectDuties { get; set; }
      
        public virtual ICollection<ProjectTechnique> ProjectTechniques { get; set; }

    }
}
