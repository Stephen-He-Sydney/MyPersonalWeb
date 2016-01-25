using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public string SkillLevel { get; set; }
    }
}
