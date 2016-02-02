using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PersonalDemo.Web.Cache;
using PersonalDemo.Data.EnumTypes;
using PersonalDemo.Data.Domain;
using PersonalDemo.Service.Projects;
using PersonalDemo.Web.Models.Project;
using PersonalDemo.Web.EnumHelpers;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class ProjectDataController : ApiController
    {
        #region Global variable
        private IProjectService _projectService;
        #endregion

        #region Constructor injection
        public ProjectDataController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        #endregion

        #region Core
        [HttpGet]
        [Route("projects")]
        public HttpResponseMessage GetProjects()
        {
            IList<ProjectModel> projectList = GetAllProject();

            if (projectList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, projectList);
        }
        #endregion

        #region Support functions
        [NonAction]
        private List<ProjectModel> GetAllProject()
        {
            List<ProjectModel> projectList = new List<ProjectModel>();

            IList<Project> projects = new List<Project>();

            if (HttpRuntime.Cache["Project"] != null)
            {
                projects = HttpRuntime.Cache["Project"] as List<Project>;
            }
            else
            {
                projects = _projectService.GetAllWithSubTables().ToList();
                SqlCacheHelper.FetchFromDb("Project", projects);
            }

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

            return projectList;
        }
        #endregion
    }
}
