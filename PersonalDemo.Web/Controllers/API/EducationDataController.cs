using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PersonalDemo.Web.Cache;
using PersonalDemo.Service.Educations;
using PersonalDemo.Data.Domain;


namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class EducationDataController : ApiController
    {
        #region Global variable
        private IEducationService _educationService;
        #endregion

        #region Constructor injection
        public EducationDataController(IEducationService educationService)
        {
            _educationService = educationService;
        }
        #endregion

        #region Core
        [HttpGet]
        [Route("education")]
        public HttpResponseMessage GetEduBackground()
        {
            IList<Education> educationList = new List<Education>(); 

            if (HttpRuntime.Cache["Education"] != null)
            {
                educationList = HttpRuntime.Cache["Education"] as List<Education>;
            }
            else
            {
                educationList = _educationService.GetAll().ToList();
                SqlCacheHelper.FetchFromDb("Education", educationList);
            }

            if (educationList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, educationList);
        }
        #endregion
    }
}
