using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalDemo.Service.Referees;
using PersonalDemo.Data;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class RefereeDataController : ApiController
    {
        private IRefereeService _refereeService;

        public RefereeDataController(IRefereeService refereeService)
        {
            _refereeService = refereeService;
        }

        [HttpGet]
        [Route("referees")]
        public HttpResponseMessage GetReferees()
        {
            List<Referee> refereeList = _refereeService.GetAll().ToList();

            if (refereeList.Count == 0) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, refereeList);
        }

    }
}
