using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalDemo.Web.Models.Project
{
    public class ProjectModel
    {
        public ProjectModel() 
        {
            ProjectDutyList = new List<ProjectDutyModel>();
            ProjectTechList = new List<ProjectTechModel>();
        }

        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Language { get; set; }
        public string DevelopmentTool { get; set; }
        public string TypeName { get; set; }
        public List<ProjectDutyModel> ProjectDutyList { get; set; }
        public List<ProjectTechModel> ProjectTechList { get; set; }
    }
}