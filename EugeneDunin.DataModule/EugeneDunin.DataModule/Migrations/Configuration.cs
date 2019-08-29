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

            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    Name = "Иван",
                    Surname = "Иванов",
                    Patronymic = "Иванович",
                    StudyLoad = 50
                },
                new Teacher()
                {
                    Name = "Пётр",
                    Surname = "Петров",
                    Patronymic = "Петрович",
                    StudyLoad = 50
                }
            };

            var classes = new List<Class>()
            {
                new Class() {Number = 10, Label = "A"},
                new Class() {Number = 11, Label = "A"},
            };

            var firstSubjectsSet = new List<Subject>()
            {
                new Subject() {SubjectName = "Алгебра"},
                new Subject() {SubjectName = "Геометрия"}
            };

            var secondSubjectsSet = new List<Subject>()
            {
                new Subject() {SubjectName = "Биология"},
            };

            var classroom = new Classroom()
            {
                Number = 402,
                Label = "a"
            };

            teachers[0].Subjects = firstSubjectsSet;
            classes[0].Teacher = teachers[0];

            teachers[1].Subjects = secondSubjectsSet;
            classes[1].Teacher = teachers[1];

            var teacherWorkLoad = new TeacherWorkloadSchedule()
            {

                Teacher = teachers[0],
                Class = classes[0],
                Classroom = classroom,
                FromDate = new DateTime(2019, 1, 1),
                ToDate = new DateTime(2020, 1, 1),
                LessonNumber = 1,
                DayOfWeek = DayOfWeek.Monday,
                StudyLoad = 5,
            };

            context.Classrooms
                .AddOrUpdate(classroomEntity => new {classroomEntity.Number, classroomEntity.Label}, classroom);

            context.Classes.AddOrUpdate(classEntity => new { classEntity.Number, classEntity.Label }, classes.ToArray());

            context.Teachers
                .AddOrUpdate(
                    teacherEntity => new {teacherEntity.Name, teacherEntity.Surname, teacherEntity.Patronymic},
                    teachers.ToArray());

            context.Subjects.AddOrUpdate(subject => subject.SubjectName, firstSubjectsSet.Union(secondSubjectsSet).ToArray());

           /* context.TeacherWorkloadSchedules
                .AddOrUpdate(teacherWorkLoadEntity => 
                    new
                    {
                        teacherWorkLoadEntity.LessonNumber, teacherWorkLoadEntity.DayOfWeek,
                        teacherWorkLoadEntity.FkTeacherId, teacherWorkLoadEntity.FkClassId
                    },
                    teacherWorkLoad);*/

            context.SaveChanges();
        }
    }
}