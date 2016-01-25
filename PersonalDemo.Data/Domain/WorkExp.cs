using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalDemo.Data.Domain
{
    public class WorkExp
    {
        public WorkExp()
        {
            this.Achievements = new HashSet<Achievement>();
            this.PositionDuties = new HashSet<PositionDuty>();
        }

        [Key]
        public int WorkExpID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string CorpName { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }
        public virtual ICollection<PositionDuty> PositionDuties { get; set; }
    }
}
