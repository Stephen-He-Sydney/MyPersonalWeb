using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalDemo.Data.Domain;
using PersonalDemo.Service.WorkExps;
using PersonalDemo.Web.Models.WorkExp;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class WorkExpDataController : ApiController
    {
        private IWorkExpService _workExpService;

        public WorkExpDataController(IWorkExpService workExpService)
        {
            _workExpService = workExpService;
        }

        [HttpGet]
        [Route("workExps")]
        public HttpResponseMessage GetWorkExperiences()
        {
            List<WorkExpModel> workExpList = new List<WorkExpModel>();
            var workExps = _workExpService.GetAllWithSubTables().ToList();

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
    }
}
