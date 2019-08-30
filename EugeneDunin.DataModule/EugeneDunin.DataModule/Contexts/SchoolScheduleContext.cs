using System.Data.Entity;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.DataModule.Entities.Configurations;
using EugeneDunin.SchoolSchedule.DataModule.Migrations;

namespace EugeneDunin.SchoolSchedule.DataModule.Contexts
{
    public class SchoolScheduleContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherWorkloadSchedule> TeacherWorkloadSchedules { get; set; }


        public SchoolScheduleContext() : base("SchoolScheduleDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolScheduleContext, Configuration>());
            //Database.SetInitializer(new SchoolScheduleInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Moved all Student related configuration to StudentEntityConfiguration class
            modelBuilder.Configurations.Add(new TeacherEntityConfiguration());

            modelBuilder.Entity<TeacherWorkloadSchedule>()
                .MapToStoredProcedures(
                    p => p.Insert(sp => sp.HasName("TeacherWorkloadSchedule_Insert")
                        .Parameter(workloadSchedule => workloadSchedule.StudyLoad, "StudyLoad")
                        .Parameter(workloadSchedule => workloadSchedule.DayOfWeek, "DayOfWeek")
                        .Parameter(workloadSchedule => workloadSchedule.LessonNumber, "LessonNumber")
                        .Parameter(workloadSchedule => workloadSchedule.FromDate, "FromDate")
                        .Parameter(workloadSchedule => workloadSchedule.ToDate, "ToDate")
                        .Parameter(workloadSchedule => workloadSchedule.FkTeacherSubjectId, "FkTeacherSubjectId")
                        .Parameter(workloadSchedule => workloadSchedule.FkTeacherSubjectId, "FkClassId")
                        .Parameter(workloadSchedule => workloadSchedule.FkClassroomId, "FkClassroomId")
                    ));

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherWorkloadSchedule>()
                .MapToStoredProcedures();
        }
    }
}