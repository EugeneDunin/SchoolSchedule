using System;
using System.Collections.Generic;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherSchedules
{
    public class TeacherScheduleProvider: ITeacherScheduleProvider
    {
        private readonly ITeacherFactory<TeacherFactoryInitializer> _teacherFactory;
        private readonly ILessonFactory<LessonFactoryInitializer> _lessonFactory;
        private readonly IClassFactory<Class> _classFactory;
        private readonly IClassroomFactory<Classroom> _classroomFactory;

        private readonly SchoolScheduleContext _ctx;

        public TeacherScheduleProvider(
            SchoolScheduleContext ctx,
            ITeacherFactory<TeacherFactoryInitializer> teacherFactory,
            ILessonFactory<LessonFactoryInitializer> lessonFactory, IClassFactory<Class> classFactory, IClassroomFactory<Classroom> classroomFactory)
        {
            _teacherFactory = teacherFactory;
            _lessonFactory = lessonFactory;
            _classFactory = classFactory;
            _classroomFactory = classroomFactory;

            _ctx = ctx;
        }


        public ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId)
        {
            var teacher = _ctx.Teachers.Find(teacherId);
            _ctx.Entry(_ctx.Teachers.Find(teacherId)).Reference(t => t.Class).Load();

            return (from t in _ctx.Teachers
                where t.TeacherId == teacherId
                join ts in _ctx.TeacherSubjects on t.TeacherId equals ts.FkTeacherId
                join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                select new TeacherSchedule(_ctx, teacherId)
                {
                    Teacher = _teacherFactory.CreateTeacher(new TeacherFactoryInitializer(t, subj)),
                    OwnClass = _classFactory.CreateClass(teacher.Class),
                    Lessons = (from twsRecord in _ctx.TeacherWorkloadSchedules
                               where twsRecord.FkTeacherSubjectId == ts.TeacherSubjectId
                               join cl in _ctx.Classes on twsRecord.FkClassId equals cl.ClassId
                               join clr in _ctx.Classrooms on twsRecord.FkClassroomId equals clr.ClassroomId
                               select _lessonFactory.CreateLesson(new LessonFactoryInitializer(twsRecord, cl, clr)))
                               .ToList()
                }).ToList() as ICollection<ITeacherSchedule>;
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