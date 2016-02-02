using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PersonalDemo.Web.Cache;
using PersonalDemo.Service.Skills;
using PersonalDemo.Data.Domain;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class SkillSumDataController : ApiController
    {
        #region Global variable
        private ISkillSummaryService _skillSummaryService;
        #endregion

        #region Constructor injection
        public SkillSumDataController(ISkillSummaryService skillSummaryService)
        {
            _skillSummaryService = skillSummaryService;
        }
        #endregion

        #region Core
        [HttpGet]
        [Route("skillSummary")]
        public HttpResponseMessage GetSkillSummary()
        {
            IList<SkillSummary> skillSummaryList = new List<SkillSummary>();

            if (HttpRuntime.Cache["SkillSummary"] != null)
            {
                skillSummaryList = HttpRuntime.Cache["SkillSummary"] as List<SkillSummary>;
            }
            else
            {
                skillSummaryList = _skillSummaryService.GetAll().ToList();
                SqlCacheHelper.FetchFromDb("SkillSummary", skillSummaryList);
            }

            if (skillSummaryList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, skillSummaryList);
        }
        #endregion
    }
}
