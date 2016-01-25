using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using PersonalDemo.Service.Profiles;
using PersonalDemo.Service.Referees;
using PersonalDemo.Service.Projects;
using PersonalDemo.Service.Skills;
using PersonalDemo.Service.Educations;
using PersonalDemo.Service.WorkExps;
using PersonalDemo.Repository;
using PersonalDemo.Data.Domain;
using PersonalDemo.Data;


namespace PersonalDemo.Service
{
    public class ServiceLayerBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, PersonalDemoContext>();

            container.RegisterType<IRepository<Referee>, EFRepository<Referee>>();
            container.RegisterType<IRepository<Project>, EFRepository<Project>>();
            container.RegisterType<IRepository<Profile>, EFRepository<Profile>>();
            container.RegisterType<IRepository<SkillSummary>, EFRepository<SkillSummary>>();
            container.RegisterType<IRepository<Education>, EFRepository<Education>>();
            container.RegisterType<IRepository<WorkExp>, EFRepository<WorkExp>>();

            container.RegisterType<IProfileService, ProfileService>();
            container.RegisterType<IRefereeService, RefereeService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<ISkillSummaryService, SkillSummaryService>();
            container.RegisterType<IEducationService, EducationService>();
            container.RegisterType<IWorkExpService, WorkExpService>();
        }
    }
}
