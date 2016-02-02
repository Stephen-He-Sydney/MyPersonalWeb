using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PersonalDemo.Web.Cache;
using PersonalDemo.Data.Domain;
using PersonalDemo.Service.WorkExps;
using PersonalDemo.Web.Models.WorkExp;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class WorkExpDataController : ApiController
    {
        #region Global variable
        private IWorkExpService _workExpService;
        #endregion

        #region Constructor injection
        public WorkExpDataController(IWorkExpService workExpService)
        {
            _workExpService = workExpService;
        }
        #endregion

        #region Core
        [HttpGet]
        [Route("workExps")]
        public HttpResponseMessage GetWorkExperiences()
        {
            List<WorkExpModel> workExpList = new List<WorkExpModel>();
            IList<WorkExp> workExps = new List<WorkExp>();

            if (HttpRuntime.Cache["WorkExp"] != null)
            {
                workExps = HttpRuntime.Cache["WorkExp"] as List<WorkExp>;
            }
            else
            {
                workExps = _workExpService.GetAllWithSubTables().ToList();
                SqlCacheHelper.FetchFromDb("WorkExp", workExps);
            }

            foreach (var aworkExp in workExps)
            {
                WorkExpModel workExpModel = new WorkExpModel();
                workExpModel.StartDate = aworkExp.StartDate;
                workExpModel.EndDate = aworkExp.EndDate;
                workExpModel.CorpName = aworkExp.CorpName;
                workExpModel.Location = aworkExp.Location;
                workExpModel.Position = aworkExp.Position;

                foreach (var apositionDuty in aworkExp.PositionDuties)
                {
                    PositionDutyModel positionDutyModel = new PositionDutyModel();
                    positionDutyModel.ListItem = apositionDuty.ListItem;
                    workExpModel.positionDutyList.Add(positionDutyModel);
                }
                workExpList.Add(workExpModel);
            }

            if (workExpList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, workExpList);
        }
        #endregion
    }
}
