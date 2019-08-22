using EugeneDunin.DataModule.Entities;
using System.Data.Entity;

namespace EugeneDunin.DataModule.Contexts
{
    class SchoolScheduleContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherWorkloadSchedule> TeacherWorkloadSchedules { get; set; }
    }
}