using System;
using System.Collections.Generic;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.Foundation.Abstractions;
using EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherSchedules
{
    public class TeacherScheduleProvider: ContextInitBase, ITeacherScheduleProvider
    {
        private readonly ITeacherFactory<TeacherFactoryInitializer> teacherFactory;
        private readonly ILessonFactory<LessonFactoryInitializer> lessonFactory;
        private readonly IClassFactory<Class> classFactory;
        private readonly IClassroomFactory<Classroom> classroomFactory;


        public TeacherScheduleProvider(
            SchoolScheduleContext ctx,
            ITeacherFactory<TeacherFactoryInitializer> teacherFactory,
            ILessonFactory<LessonFactoryInitializer> lessonFactory, IClassFactory<Class> classFactory, IClassroomFactory<Classroom> classroomFactory) : base(ctx)
        {
            this.teacherFactory = teacherFactory;
            this.lessonFactory = lessonFactory;
            this.classFactory = classFactory;
            this.classroomFactory = classroomFactory;
        }


        public ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId)
        {
            var teacher = Ctx.Teachers.Find(teacherId);
            Ctx.Entry(Ctx.Teachers.Find(teacherId)).Reference(t => t.Class).Load();

            return (from t in Ctx.Teachers
                where t.TeacherId == teacherId
                join ts in Ctx.TeacherSubjects on t.TeacherId equals ts.FkTeacherId
                join subj in Ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                join tws in Ctx.TeacherWorkloadSchedules on ts.TeacherSubjectId equals tws.FkTeacherSubjectId
                join clr in Ctx.Classrooms on tws.FkClassroomId equals clr.ClassroomId
                select new TeacherSchedule(Ctx, teacherId)
                {
                    Classroom = classroomFactory.CreatClassroom(clr),
                    Teacher = teacherFactory.CreateTeacher(new TeacherFactoryInitializer(t, subj)),
                    DayOfWeek = tws.DayOfWeek,
                    OwnClass = classFactory.CreateClass(Ctx, teacher.Class),
                    Lessons = (from twsRecord in Ctx.TeacherWorkloadSchedules
                            join cl in Ctx.Classes on twsRecord.FkClassId equals cl.ClassId
                            select lessonFactory.CreateLesson(new LessonFactoryInitializer(tws, cl)))
                        .ToList()
                }) as ICollection<ITeacherSchedule>;
        }

        public ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName)
        {
            throw new NotImplementedException();
        }

        public ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName, DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public ICollection<ITeacherSchedule> GetTeachersWorkLoad(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}