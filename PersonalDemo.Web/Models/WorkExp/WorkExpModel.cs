using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalDemo.Web.Models.WorkExp
{
    public class WorkExpModel
    {
        public WorkExpModel()
        {
            positionDutyList = new List<PositionDutyModel>();
        }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CorpName { get; set; }
        public string Location { get; set; }
        public string Position { get; set; }
        public List<PositionDutyModel> positionDutyList { get; set; }
    }
}