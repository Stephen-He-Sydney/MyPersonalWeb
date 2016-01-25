using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data;

namespace PersonalDemo.Service.WorkExps
{
    public class WorkExpService:IWorkExpService
    {
        private IRepository<WorkExp> _workExpRepository;

        public WorkExpService(IRepository<WorkExp> workExpRepository)
        {
            _workExpRepository = workExpRepository;
        }

        public IQueryable<WorkExp> GetAllWithSubTables()
        {
            return _workExpRepository.GetAll()
                                     .Include(p=>p.PositionDuties);
        }

        public IQueryable<WorkExp> GetAll()
        {
            return _workExpRepository.GetAll();
        }
    }
}
