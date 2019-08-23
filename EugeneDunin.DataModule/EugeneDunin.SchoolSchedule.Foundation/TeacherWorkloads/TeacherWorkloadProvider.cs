using System;
using System.Collections.Generic;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads
{
    public class TeacherWorkloadProvider : ITeacherWorkloadProvider
    {
        private readonly SchoolScheduleContext _ctx;
        private readonly ITeacherWorkloadFactory _teacherWorkloadFactory;


        public TeacherWorkloadProvider(SchoolScheduleContext ctx, ITeacherWorkloadFactory teacherWorkloadFactory)
        {
            _ctx = ctx;
            _teacherWorkloadFactory = teacherWorkloadFactory;
        }


        public ICollection<ITeacherWorkload> GetTecherWorkLoad(long teacherId, DateTime start, DateTime end)
        {
            var teacherWorkloadSchedules = _ctx.TeacherWorkloadSchedules.Where(teacherWorkload =>
                teacherWorkload.FkTeacherId == teacherId);
            var teacherWorkloads = new List<ITeacherWorkload>();
            foreach (var teacherWorkloadSchedule in teacherWorkloadSchedules)
            {
                teacherWorkloads.Add(_teacherWorkloadFactory.CreateTeacherWorkload(teacherWorkloadSchedule));
            }

            return teacherWorkloads;
        }


        public ICollection<ITeacherWorkload> GetTechersWorkLoad(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }
    }
}
