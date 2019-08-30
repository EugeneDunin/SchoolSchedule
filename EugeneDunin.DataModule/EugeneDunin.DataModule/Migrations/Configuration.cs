using System.Collections.Generic;
using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.DataModule.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexts.SchoolScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EugeneDunin.SchoolSchedule.DataModule.Contexts.SchoolScheduleContext";
            AutomaticMigrationDataLossAllowed = true;
        }


        protected override void Seed(Contexts.SchoolScheduleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    Name = "����",
                    Surname = "������",
                    Patronymic = "��������",
                    StudyLoad = 50
                },
                new Teacher()
                {
                    Name = "ϸ��",
                    Surname = "������",
                    Patronymic = "��������",
                    StudyLoad = 50
                }
            };

            var classes = new List<Class>()
            {
                new Class() {Number = 10, Label = "A"},
                new Class() {Number = 11, Label = "A"},
            };

            classes[0].Teacher = teachers[0];
            classes[1].Teacher = teachers[1];

            var subjects = new List<Subject>()
            {
                new Subject() {SubjectName = "�������"},
                new Subject() {SubjectName = "���������"},
                new Subject() {SubjectName = "��������"},
            };

            var classroom = new Classroom()
            {
                Number = 402,
                Label = "a"
            };

            var teacherSubjects = new List<TeacherSubject>()
            {
                AssosiateTeacherWithSubject(teachers[0], subjects[0]),
                AssosiateTeacherWithSubject(teachers[0], subjects[1]),
                AssosiateTeacherWithSubject(teachers[1], subjects[2])
            };

            var teacherWorkLoad = new TeacherWorkloadSchedule()
            {
                FromDate = new DateTime(2019, 1, 1),
                ToDate = new DateTime(2020, 1, 1),
                LessonNumber = 1,
                DayOfWeek = DayOfWeek.Monday,
                StudyLoad = 5,
                Classroom = classroom,
                TeacherSubject = teacherSubjects[0]
            };

            context.Classrooms
                .AddOrUpdate(classroomEntity => new {classroomEntity.Number, classroomEntity.Label}, classroom);

            context.Classes.AddOrUpdate(classEntity => new { classEntity.Number, classEntity.Label }, classes.ToArray());

            context.Teachers
                .AddOrUpdate(
                    teacherEntity => new {teacherEntity.Name, teacherEntity.Surname, teacherEntity.Patronymic},
                    teachers.ToArray());

            context.Subjects.AddOrUpdate(subject => new { subject.SubjectName }, subjects.ToArray());

            context.TeacherSubjects.AddOrUpdate(teacherSubjects.ToArray());

            context.SaveChanges();
        }

        
        private TeacherSubject AssosiateTeacherWithSubject(Teacher teacher, Subject subject)
        {
            return new TeacherSubject()
            {
                Teacher = teacher,
                Subject = subject
            };
        }
    }
}