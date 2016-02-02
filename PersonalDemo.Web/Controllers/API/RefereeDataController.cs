using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PersonalDemo.Web.Cache;
using PersonalDemo.Service.Referees;
using PersonalDemo.Data.Domain;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class RefereeDataController : ApiController
    {
        #region Global variable
        private IRefereeService _refereeService;
        #endregion

        #region Constructor injection 
        public RefereeDataController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }
        #endregion

        #region Core
        [HttpGet]
        [Route("referees")]
        public HttpResponseMessage GetReferees()
        {
            IList<Referee> refereeList = new List<Referee>();

            if (HttpRuntime.Cache["Referee"] != null)
            {
                refereeList = HttpRuntime.Cache["Referee"] as List<Referee>;
            }
            else
            {
                refereeList = _refereeService.GetAll().ToList();
                SqlCacheHelper.FetchFromDb("Referee", refereeList);
            }

            if (refereeList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, refereeList);
        }
        #endregion
    }
}
