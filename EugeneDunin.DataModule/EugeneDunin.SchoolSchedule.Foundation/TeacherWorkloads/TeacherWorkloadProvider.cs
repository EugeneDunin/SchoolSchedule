using System;
using System.Collections.Generic;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
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


        public ICollection<ITeacherWorkload> GetTecherWorkLoad(long teacherId, DateTime fromDate, DateTime toDate)
        {
            var teacherWorkloadSchedules = _ctx.TeacherWorkloadSchedules.Where(teacherWorkload =>
                teacherWorkload.FkTeacherId == teacherId 
                && teacherWorkload.FromDate >= fromDate
                && teacherWorkload.ToDate <= toDate)
                .ToList();

            return CreateTeacherWorkloads(teacherWorkloadSchedules);
        }

        public IDictionary<long, ICollection<ITeacherWorkload>> GetTechersWorkLoad(DateTime fromDate, DateTime toDate)
        {
            var teacherWorkloadSchedules = _ctx.TeacherWorkloadSchedules
                .Where(teacherWorkload => teacherWorkload.FromDate >= fromDate && teacherWorkload.ToDate <= toDate)
                .GroupBy(teacherWorkload => teacherWorkload.TeacherWorkloadScheduleId)
                .ToList();

            IDictionary<long, ICollection<ITeacherWorkload>> result = new Dictionary<long, ICollection<ITeacherWorkload>>();
            teacherWorkloadSchedules.ForEach(teacherWorkLoadGroup =>
                result.Add(teacherWorkLoadGroup.Key, CreateTeacherWorkloads(teacherWorkLoadGroup.AsEnumerable()))
                );

            return result;
        }


        private ICollection<ITeacherWorkload> CreateTeacherWorkloads(IEnumerable<TeacherWorkloadSchedule> teacherWorkloads)
        {
            var converted = new List<ITeacherWorkload>();
            foreach (var teacherWorkload in teacherWorkloads)
            {
                converted.Add(_teacherWorkloadFactory.CreateTeacherWorkload(teacherWorkload));
            }

            return converted;
        }
    }
}