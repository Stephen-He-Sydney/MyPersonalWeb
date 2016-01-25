using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalDemo.Service.Skills;
using PersonalDemo.Data;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class SkillSumDataController : ApiController
    {
        private ISkillSummaryService _skillSummaryService;

        public SkillSumDataController(ISkillSummaryService skillSummaryService)
        {
            _skillSummaryService = skillSummaryService;
        }

        [HttpGet]
        [Route("skillSummary")]
        public HttpResponseMessage GetSkillSummary()
        {
            List<SkillSummary> skillSummaryList = _skillSummaryService.GetAll().ToList();

            if (skillSummaryList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, skillSummaryList);
        }
    }
}
