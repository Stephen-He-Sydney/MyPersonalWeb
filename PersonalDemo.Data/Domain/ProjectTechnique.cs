using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class ProjectTechnique
    {
        [Key]
        public int ProjectTechniqueID { get; set; }
        public string ListItem { get; set; }
        public int ProjectID { get; set; }

        public virtual Project Project { get; set; }
    }
}
