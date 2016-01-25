using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Skills
{
    public interface ISkillSummaryService
    {
        IQueryable<SkillSummary> GetAll();
    }
}
