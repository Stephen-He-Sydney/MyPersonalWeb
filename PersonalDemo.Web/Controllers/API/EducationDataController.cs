using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalDemo.Service.Educations;
using PersonalDemo.Data.Domain;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class EducationDataController : ApiController
    {
        private IEducationService _educationService;

        public EducationDataController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        [Route("education")]
        public HttpResponseMessage GetEduBackground()
        {
            List<Education> educationList = _educationService.GetAll().ToList();

            if (educationList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, educationList);
        }

    }
}
