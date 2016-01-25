using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalDemo.Data;
using PersonalDemo.Data.EnumTypes;
using PersonalDemo.Service.Projects;
using PersonalDemo.Web.Models.Project;
using PersonalDemo.Web.EnumHelpers;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class ProjectDataController : ApiController
    {
        private IProjectService _projectService;

        public ProjectDataController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("projects")]
        public HttpResponseMessage GetProjects()
        {
            List<ProjectModel> projectList = new List<ProjectModel>();
            var projects = _projectService.GetAllWithSubTables().ToList();

            foreach (var aProject in projects)
            {
                ProjectModel projectModel = new ProjectModel();
                projectModel.Name = aProject.Name;
                projectModel.Purpose = aProject.Purpose;
                projectModel.Language = aProject.Language;
                projectModel.DevelopmentTool = aProject.DevelopmentTool;

                ProjectType projectTypeVal = (ProjectType)Enum.Parse(typeof(ProjectType), aProject.ProjectTypeID.ToString());
                projectModel.TypeName = EnumExtensions.GetDisplayName(projectTypeVal);

                foreach (var aprojectDuty in aProject.ProjectDuties)
                {
                    ProjectDutyModel projectDutyModel = new ProjectDutyModel();
                    projectDutyModel.ListItem = aprojectDuty.ListItem;
                    projectModel.ProjectDutyList.Add(projectDutyModel);
                }
                foreach (var aprojectTech in aProject.ProjectTechniques)
                {
                    ProjectTechModel projectTechModel = new ProjectTechModel();
                    projectTechModel.ListItem = aprojectTech.ListItem;
                    projectModel.ProjectTechList.Add(projectTechModel);
                }

                projectList.Add(projectModel);
            }

            if (projectList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, projectList);
        }
    }
}
