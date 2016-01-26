using System;
using System.Data.Entity;
using PersonalDemo.Data.Domain;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PersonalDemo.Data
{
    public class PersonalDemoContext : DbContext
    {
        public PersonalDemoContext()
            : base("name=PersonalDemoContext")
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectDuty> ProjectDuties { get; set; }
        public virtual DbSet<ProjectTechnique> ProjectTechniques { get; set; }
        public virtual DbSet<SkillSummary> SkillSummaries { get; set; }
        public virtual DbSet<WorkExp> WorkExps { get; set; }
        public virtual DbSet<Referee> Referees { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<PositionDuty> PositionDuties { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here

            base.OnModelCreating(modelBuilder);
            //Database.SetInitializer(new DropCreateDatabaseAlways<PersonalDemoContext>());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
