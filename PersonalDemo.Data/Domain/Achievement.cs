using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDemo.Data.Domain
{
    public class Achievement
    {
        [Key]
        public int AchievementID { get; set; }
        public string ListItem { get; set; }
        public int WorkExpID { get; set; }

        public virtual WorkExp WorkExp { get; set; }
    }
}
