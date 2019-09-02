using System;
using System.Collections.Generic;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.Foundation.ClassLoads;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads
{
    public class TeacherWorkloadProvider : ITeacherWorkloadProvider
    {
        private readonly SchoolScheduleContext _ctx;
        private readonly IClassFactory<Class> _classFactory;

        public TeacherWorkloadProvider(
            SchoolScheduleContext ctx,
            IClassFactory<Class> classFactory)
        {
            _ctx = ctx;
            _classFactory = classFactory;
        }


        public ICollection<ITeacherWorkload> GetTeacherWorkLoad(long teacherId)
        {
            return GetTeacherWorkLoad(teacherId, (tws, ts) => tws.FkTeacherSubjectId == ts.TeacherSubjectId);

            /*var teacher = _ctx.Teachers.Find(teacherId);

            return (ICollection<ITeacherWorkload>)
                    (from ts in _ctx.TeacherSubjects
                    where ts.FkTeacherId == teacher.TeacherId
                    join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                    select new TeacherWorkload
                    {
                        TeacherFullName = string.Format(@"{0} {1} {2}", teacher.Surname, teacher.Name, teacher.Patronymic),
                        SubjectName = subj.SubjectName,
                        ClassLoads = (from tws in _ctx.TeacherWorkloadSchedules
                                      where tws.FkTeacherSubjectId == ts.TeacherSubjectId
                                      join cl in _ctx.Classes on tws.FkClassId equals cl.ClassId
                                      select CreateClassLoads(cl, tws))
                                        .ToList()
                    }).ToList();*/
        }

        public ICollection<ITeacherWorkload> GetTeacherWorkLoad(long teacherId, DateTime fromDate, DateTime toDate)
        {
            return GetTeacherWorkLoad(teacherId,
                ((tws, ts) => tws.FkTeacherSubjectId == ts.TeacherSubjectId && tws.FromDate >= fromDate && tws.ToDate <= toDate));
        }

        public ICollection<ITeacherWorkload> GetTeachersWorkLoad(DateTime fromDate, DateTime toDate)
        {
            return GetTeachersWorkLoad(null, (tws) => tws.FromDate >= fromDate && tws.ToDate <= toDate);
        }

        public ICollection<ITeacherWorkload> GetTeachersWorkLoad(string subjectName)
        {
            return GetTeachersWorkLoad(s => s.SubjectName == subjectName, null);
        }

        public ICollection<ITeacherWorkload> GetTeachersWorkLoad(string subjectName, DateTime fromDate, DateTime toDate)
        {
            return GetTeachersWorkLoad(
                s => s.SubjectName == subjectName,
                tws => tws.FromDate >= fromDate && tws.ToDate <= toDate);
        }


        private ICollection<ITeacherWorkload> GetTeacherWorkLoad(long teacherId, Func<TeacherWorkloadSchedule, TeacherSubject, bool> FilterCondition)
        {
            var teacher = _ctx.Teachers.Find(teacherId);

            return (from ts in _ctx.TeacherSubjects
                where ts.FkTeacherId == teacher.TeacherId
                join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                select new TeacherWorkload(_ctx, teacherId)
                {
                    Name = teacher.Name,
                    Surname = teacher.Surname,
                    Patronymic = teacher.Patronymic,
                    SubjectName = subj.SubjectName,
                    ClassLoads = (from tws in _ctx.TeacherWorkloadSchedules
                            where FilterCondition(tws, ts)
                            join cl in _ctx.Classes on tws.FkClassId equals cl.ClassId
                            select CreateClassLoads(cl, tws))
                        .ToList()
                }).ToList() as ICollection<ITeacherWorkload>;
        }

        private ICollection<ITeacherWorkload> GetTeachersWorkLoad(Func<Subject, bool> subjectFilter, Func<TeacherWorkloadSchedule, bool> twsFilter)
        {
            return (from t in _ctx.Teachers
                join ts in _ctx.TeacherSubjects on t.TeacherId equals ts.FkTeacherId
                join subj in _ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                where subjectFilter(subj)
                select new TeacherWorkload(_ctx, t.TeacherId)
                {
                    Name = t.Name,
                    Surname = t.Surname,
                    Patronymic = t.Patronymic,
                    SubjectName = subj.SubjectName,
                    ClassLoads = (from tws in _ctx.TeacherWorkloadSchedules
                            where tws.FkTeacherSubjectId == ts.TeacherSubjectId && twsFilter(tws)
                            join cl in _ctx.Classes on tws.FkClassId equals cl.ClassId
                            select CreateClassLoads(cl, tws))
                        .ToList()
                }).ToList() as ICollection<ITeacherWorkload>;
        }

        private IClassLoad CreateClassLoads(
            Class cl, TeacherWorkloadSchedule teacherWorkloadSchedule)
        {
            return new ClassLoad(_ctx, teacherWorkloadSchedule.TeacherWorkloadScheduleId)
            {
                StudyLoadToClass = teacherWorkloadSchedule.StudyLoad,
                Class = _classFactory.CreateClass(_ctx, cl)
            };
        }
    }
}