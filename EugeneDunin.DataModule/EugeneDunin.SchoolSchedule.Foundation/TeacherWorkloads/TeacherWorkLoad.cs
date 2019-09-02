using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals;
using System.Collections.Generic;
using System.Linq;
using EugeneDunin.SchoolSchedule.Foundation.Abstractions;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads
{
    public sealed class TeacherWorkload : LogicEntityBase, ITeacherWorkloadInternal
    {
        public long Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string SubjectName { get; set; }
        public ICollection<IClassLoad> ClassLoads { get; set; }


        public TeacherWorkload(SchoolScheduleContext ctx, long id): base(ctx)
        {
            Id = id;
        }


        public void Delete()
        {
            foreach (var classLoad in ClassLoads)
            {
                classLoad.Delete();
            }
        }

        public void Update()
        {
            foreach (var classLoad in ClassLoads)
            {
                classLoad.Update();
            }
        }
    }
}