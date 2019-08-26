using System.Collections.Generic;
using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.DataModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EugeneDunin.SchoolSchedule.DataModule.Contexts.SchoolScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EugeneDunin.SchoolSchedule.DataModule.Contexts.SchoolScheduleContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EugeneDunin.SchoolSchedule.DataModule.Contexts.SchoolScheduleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var teacher = new Teacher()
            {
                Name = "����",
                Surname = "������",
                Patronymic = "��������",
                StudyLoad = 50
            };

            var @class = new Class()
            {
                Number = 10,
                Label = "A"
            };

            ICollection<Subject> subjects = new List<Subject>()
            {
                new Subject() {SubjectName = "�������"},
                new Subject() {SubjectName = "���������"}
            };

            var classroom = new Classroom()
            {
                Number = 402,
                Label = "a"
            };

            teacher.Subjects = subjects;
            @class.Teacher = teacher;

            var teacherWorkLoad = new TeacherWorkloadSchedule()
            {

                Teacher = teacher,
                Class = @class,
                Classroom = classroom,
                FromDate = new DateTime(2019, 1, 1),
                ToDate = new DateTime(2020, 1, 1),
                LessonNumber = 1,
                DayOfWeek = DayOfWeek.Monday,
                StudyLoad = 5
            };

            context.Classrooms
                .AddOrUpdate(classroomEntity => new {classroomEntity.Number, classroomEntity.Label}, classroom);

            context.Classes.AddOrUpdate(@class);

            context.Teachers
                .AddOrUpdate(
                    teacherEntity => new {teacherEntity.Name, teacherEntity.Surname, teacherEntity.Patronymic},
                    teacher);

            context.Subjects.AddOrUpdate(subject => subject.SubjectName, subjects.ToArray());

            context.TeacherWorkloadSchedules.AddOrUpdate(teacherWorkLoad);

            context.SaveChanges();
        }
    }
}