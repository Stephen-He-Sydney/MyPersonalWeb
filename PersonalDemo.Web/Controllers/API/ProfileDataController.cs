using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PersonalDemo.Web.Cache;
using PersonalDemo.Service.Profiles;
using PersonalDemo.Data.Domain;

namespace PersonalDemo.Web.Controllers.API
{
    [RoutePrefix("api")]
    public class ProfileDataController : ApiController
    {
        #region Global variable
        private IProfileService _profileService;
        #endregion

        #region Constructor injection
        public ProfileDataController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        #endregion

        #region Core
        [HttpGet]
        [Route("profile")]
        public HttpResponseMessage GetProfile()
        {
            IList<Profile> allProfile = new List<Profile>();

            if (HttpRuntime.Cache["Profile"] != null)
            {
                allProfile = HttpRuntime.Cache["Profile"] as List<Profile>;
            }
            else
            {
                allProfile = _profileService.GetAll().ToList();
                SqlCacheHelper.FetchFromDb("Profile", allProfile);
            }

            if (allProfile.FirstOrDefault() == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return Request.CreateResponse(HttpStatusCode.OK, allProfile.FirstOrDefault());
        }

        [HttpGet]
        [Route("briefIntro")]
        public HttpResponseMessage GetBriefIntro()
        {
            var profile = _profileService.GetAll().FirstOrDefault();
            string briefIntro = profile != null ? profile.CareerObjective : string.Empty;

            return Request.CreateResponse(HttpStatusCode.OK, briefIntro);
        }
        #endregion
    }
}
