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
            return GetTeacherSchedule(teacherId, (tws, ts) => tws.FkTeacherSubjectId == ts.TeacherSubjectId);

            /*var teacher = _ctx.Teachers.Find(teacherId);
            _ctx.Entry(_ctx.Teachers.Find(teacherId)).Reference(t => t.Class).Load();

            return (from ts in _ctx.TeacherSubjects
                    where ts.FkTeacherId == teacher.TeacherId
                    join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                select new TeacherSchedule(teacherId)
                {
                    Teacher = _teacherFactory.CreateTeacher(new TeacherFactoryInitializer(teacher, subj)),
                    OwnClass = _classFactory.CreateClass(teacher.Class),
                    Lessons = (from twsRecord in _ctx.TeacherWorkloadSchedules
                               where twsRecord.FkTeacherSubjectId == ts.TeacherSubjectId
                               join cl in _ctx.Classes on twsRecord.FkClassId equals cl.ClassId
                               join clr in _ctx.Classrooms on twsRecord.FkClassroomId equals clr.ClassroomId
                               select _lessonFactory.CreateLesson(new LessonFactoryInitializer(twsRecord, cl, clr)))
                               .ToList()
                }).ToList() as ICollection<ITeacherSchedule>;*/
        }

        public ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId, DateTime fromDate, DateTime toDate)
        {
            return GetTeacherSchedule(teacherId,
                ((tws, ts) => tws.FkTeacherSubjectId == ts.TeacherSubjectId && tws.FromDate >= fromDate && tws.ToDate <= toDate));
        }

        public ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName)
        {
            return GetTeachersSchedule(s => s.SubjectName == subjectName, null);
        }

        public ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName, DateTime fromDate, DateTime toDate)
        {
            return GetTeachersSchedule(
                s => s.SubjectName == subjectName,
                tws => tws.FromDate >= fromDate && tws.ToDate <= toDate);
        }

        public ICollection<ITeacherSchedule> GetTeachersWorkLoad(DateTime fromDate, DateTime toDate)
        {
            return GetTeachersSchedule(null, (tws) => tws.FromDate >= fromDate && tws.ToDate <= toDate);
        }


        private ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId, Func<TeacherWorkloadSchedule, TeacherSubject, bool> FilterCondition)
        {
            var teacher = _ctx.Teachers.Find(teacherId);
            _ctx.Entry(_ctx.Teachers.Find(teacherId)).Reference(t => t.Class).Load();

            return (from ts in _ctx.TeacherSubjects
                where ts.FkTeacherId == teacher.TeacherId
                join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                select new TeacherSchedule(teacherId)
                {
                    TeacherInfo = _teacherFactory.CreateTeacher(new TeacherFactoryInitializer(teacher, subj)),
                    OwnClass = _classFactory.CreateClass(teacher.Class),
                    Lessons = (from twsRecord in _ctx.TeacherWorkloadSchedules
                            where FilterCondition(twsRecord, ts)
                            join cl in _ctx.Classes on twsRecord.FkClassId equals cl.ClassId
                            join clr in _ctx.Classrooms on twsRecord.FkClassroomId equals clr.ClassroomId
                            select _lessonFactory.CreateLesson(new LessonFactoryInitializer(twsRecord, cl, clr)))
                            .ToList()
                }).ToList() as ICollection<ITeacherSchedule>;
        }

        private ICollection<ITeacherSchedule> GetTeachersSchedule(Func<Subject, bool> subjectFilter, Func<TeacherWorkloadSchedule, bool> twsFilter)
        {

            return (from t in _ctx.Teachers
                join ts in _ctx.TeacherSubjects on t.TeacherId equals ts.FkTeacherId
                join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                where subjectFilter(subj)
                select new TeacherSchedule(t.TeacherId)
                {
                    TeacherInfo = _teacherFactory.CreateTeacher(new TeacherFactoryInitializer(t, subj)),
                    OwnClass = _classFactory.CreateClass(t.Class),
                    Lessons = (from twsRecord in _ctx.TeacherWorkloadSchedules
                            where twsRecord.FkTeacherSubjectId == ts.TeacherSubjectId && twsFilter(twsRecord)
                            join cl in _ctx.Classes on twsRecord.FkClassId equals cl.ClassId
                            join clr in _ctx.Classrooms on twsRecord.FkClassroomId equals clr.ClassroomId
                            select _lessonFactory.CreateLesson(new LessonFactoryInitializer(twsRecord, cl, clr)))
                        .ToList()
                }).ToList() as ICollection<ITeacherSchedule>;
        }
    }
}