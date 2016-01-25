using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Referees
{
    public class RefereeService:IRefereeService
    {
        private IRepository<Referee> _refereeRepository;

        public RefereeService(IRepository<Referee> refereeRepository)
        {
            _refereeRepository = refereeRepository;
        }

        public IQueryable<Referee> GetAll()
        {
            return _refereeRepository.GetAll();
        }
    }
}
