using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonalDemo.Service.Profiles;
using PersonalDemo.Data;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class ProfileDataController : ApiController
    {
        private IProfileService _profileService;

        public ProfileDataController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        [Route("profile")]
        public HttpResponseMessage GetProfile()
        {
            Profile profile = _profileService.GetAll().FirstOrDefault();
            if (profile == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, profile);
        }

        [HttpGet]
        [Route("briefIntro")]
        public HttpResponseMessage GetBriefIntro()
        {
            var profile = _profileService.GetAll().FirstOrDefault();
            string briefIntro = profile != null ? profile.CareerObjective : string.Empty;

            return Request.CreateResponse(HttpStatusCode.OK, briefIntro);
        }
    }
}
