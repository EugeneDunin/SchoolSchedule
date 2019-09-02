using System;
using System.Data.Entity;
using System.Collections.Generic;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Abstractions;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;


namespace EugeneDunin.SchoolSchedule.Foundation.TeacherSchedules
{
    public class TeacherScheduleProvider: ContextInitBase, ITeacherScheduleProvider
    {
        public TeacherScheduleProvider(SchoolScheduleContext ctx) : base(ctx)
        {
        }

        public ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId)
        {
            /*var teacher = Ctx.Teachers.Find(teacherId);

            return (ICollection<ITeacherWorkload>)
                (from ts in Ctx.TeacherSubjects
                    where ts.FkTeacherId == teacher.TeacherId
                    join subj in Ctx.Subjects on ts.FkSubjectId equals subj.SubjectId
                    select new TeacherSchedule
                    {
                        TeacherFullName = string.Format(@"{0} {1} {2}", teacher.Surname, teacher.Name, teacher.Patronymic),
                        SubjectName = subj.SubjectName,
                        ClassLoads = (from tws in _ctx.TeacherWorkloadSchedules
                                where tws.FkTeacherSubjectId == ts.TeacherSubjectId
                                join cl in _ctx.Classes on tws.FkClassId equals cl.ClassId
                                select CreateClassLoads(cl, tws))
                            .ToList()
                    }).ToList();*/
            throw new NotImplementedException();
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
