using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PersonalDemo.Service.Profiles;
using PersonalDemo.Data.Domain;
using PersonalDemo.Web.Models.Contact;
using PersonalDemo.Web.Cache;

namespace PersonalDemo.Web.Controllers.MVC
{
    public class HomeController : Controller
    {
        private IProfileService _profileService;

        public HomeController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public ActionResult Index()
        {
            ContactDetailModel contactDetail = new ContactDetailModel();
            IList<Profile> allProfile = new List<Profile>();

            if (HttpRuntime.Cache["profile"] != null)
            {
                allProfile = HttpRuntime.Cache["profile"] as List<Profile>;
            }
            else
            {
                allProfile = _profileService.GetAll().ToList();
                SqlCacheHelper.FetchFromDb("profile", allProfile);
            }

            if (allProfile.Count > 0)
            {
                contactDetail = allProfile.Select(p => new ContactDetailModel
                {
                    Phone = p.Phone,
                    Email = p.Email,
                    Street = p.Street,
                    Suburb = p.Suburb,
                    State = p.State,
                    Country = p.Country
                }).First();
            }

            return View(contactDetail);
        }
    }
}
