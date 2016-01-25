using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PersonalDemo.Repository;
using PersonalDemo.Data;

namespace PersonalDemo.Service.Projects
{
    public class ProjectService:IProjectService
    {
        private IRepository<Project> _projectRepository;

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IQueryable<Project> GetAllWithSubTables()
        {
            //eager loading
            return _projectRepository.GetAll()
                                     .Include(p => p.ProjectDuties)
                                     .Include(p => p.ProjectTechniques);
        }

        public IQueryable<Project> GetAll()
        {
            // lazy loading
            // both will load sub tables automatically
            return _projectRepository.GetAll();        
        }
    }
}
