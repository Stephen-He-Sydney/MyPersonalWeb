using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data.Domain;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Skills
{
    public class SkillService : ISkillService
    {
        private IRepository<Skill> _skillRepository;

        public SkillService(IRepository<Skill> skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public IQueryable<Skill> GetAll()
        {
            return _skillRepository.GetAll();
        }
    }
}
