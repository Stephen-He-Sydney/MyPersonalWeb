using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class SkillSummary
    {
        [Key]
        public int SkillSummaryID { get; set; }
        public string SkillStatement { get; set; }
    }
}
