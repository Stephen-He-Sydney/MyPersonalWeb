using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Educations
{
    public class EducationService :IEducationService
    {
        private IRepository<Education> _educationRepository;

        public EducationService(IRepository<Education> educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public IQueryable<Education> GetAll()
        {
            return _educationRepository.GetAll();        
        }
    }
}
