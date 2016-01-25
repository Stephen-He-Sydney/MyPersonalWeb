using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Skills
{
    public class SkillService : ISkillService
    {
        private IRepository<Skill> _skillRepository;

        public SkillService()
        {
        }

        public SkillService(PersonalDemoContext dbContext)
        {
            //_skillRepository = new EFRepository<Skill>(dbContext);
        }

        public IQueryable<Skill> GetAll()
        {
            return _skillRepository.GetAll();
        }
    }
}
