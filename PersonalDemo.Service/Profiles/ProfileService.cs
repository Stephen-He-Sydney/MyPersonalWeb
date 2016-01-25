using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Profiles
{
    public class ProfileService : IProfileService
    {
        private IRepository<Profile> _profileRepository;

        public ProfileService(IRepository<Profile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IQueryable<Profile> GetAll()
        {
            return _profileRepository.GetAll();
        }
    }
}
