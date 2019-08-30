using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.DataModule.Initializers
{
    public class SchoolScheduleInitializer : DropCreateDatabaseAlways<SchoolScheduleContext>
    {
        protected override void Seed(SchoolScheduleContext context)
        {
            /*var teacher = new Teacher()
            {
                Name = "Иван",
                Surname = "Иванов",
                Patronymic = "Иванович",
                StudyLoad = 50
            };

            var @class = new Class()
            {
                Number = 10,
                Label = "A"
            };

            ICollection<Subject> subjects = new List<Subject>()
            {
                new Subject() {SubjectName = "Алгебра"},
                new Subject() {SubjectName = "Геометрия"}
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
                .AddOrUpdate(classroomEntity => new { classroomEntity.Number, classroomEntity.Label }, classroom);

            context.Classes.AddOrUpdate(@class);

            context.Teachers
                .AddOrUpdate(
                    teacherEntity => new { teacherEntity.Name, teacherEntity.Surname, teacherEntity.Patronymic },
                    teacher);

            context.Subjects.AddOrUpdate(subject => subject.SubjectName, subjects.ToArray());

            context.TeacherWorkloadSchedules.AddOrUpdate(teacherWorkLoad);

            context.SaveChanges();

            base.Seed(context);*/
        }
    }
}