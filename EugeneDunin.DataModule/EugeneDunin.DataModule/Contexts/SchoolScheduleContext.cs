using System.Data.Entity;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.DataModule.Migrations;

namespace EugeneDunin.SchoolSchedule.DataModule.Contexts
{
    public class SchoolScheduleContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherWorkloadSchedule> TeacherWorkloadSchedules { get; set; }


        public SchoolScheduleContext() : base("SchoolScheduleDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolScheduleContext, Configuration>());
        }
    }
}