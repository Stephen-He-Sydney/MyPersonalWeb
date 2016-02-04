using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class PositionDuty
    {
        [Key]
        public int JobDutyID { get; set; }
        public string ListItem { get; set; }
        public int WorkExpID { get; set; }

        public virtual WorkExp WorkExp { get; set; }
    }
}
