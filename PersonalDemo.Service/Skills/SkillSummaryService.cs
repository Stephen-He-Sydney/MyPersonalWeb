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
    public class SkillSummaryService:ISkillSummaryService
    {
        private IRepository<SkillSummary> _skillSummaryRepository;

        public SkillSummaryService(IRepository<SkillSummary> skillSummaryRepository)
        {
            _skillSummaryRepository = skillSummaryRepository;
        }

        public IQueryable<SkillSummary> GetAll()
        {
            return _skillSummaryRepository.GetAll();
        }
    }
}
