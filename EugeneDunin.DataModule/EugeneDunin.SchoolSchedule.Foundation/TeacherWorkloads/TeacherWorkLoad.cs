using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals;
using System.Collections.Generic;
using System.Linq;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads
{
    public sealed class TeacherWorkload : ITeacherWorkloadInternal
    {
        public long Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string SubjectName { get; set; }
        public ICollection<IClassLoad> ClassLoads { get; set; }


        public TeacherWorkload(long id)
        {
            Id = id;
        }

        public void Update(SchoolScheduleContext ctx)
        {
            foreach (var classLoad in ClassLoads)
            {
                classLoad.Delete(ctx);
            }
        }

        public void Delete(SchoolScheduleContext ctx)
        {
            foreach (var classLoad in ClassLoads)
            {
                classLoad.Update(ctx);
            }
        }
    }
}