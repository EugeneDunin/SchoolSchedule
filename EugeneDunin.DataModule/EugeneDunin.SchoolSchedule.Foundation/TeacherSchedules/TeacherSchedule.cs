using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherSchedules
{
    public sealed class TeacherSchedule: ITeacherScheduleInternal
    {
        public long Id { get; }
        public ICollection<ILesson> Lessons { get; set; }
        public ITeacher Teacher { get; set; }
        public IClass OwnClass { get; set; }


        public TeacherSchedule(SchoolScheduleContext ctx, long id) : base(ctx)
        {
            Id = id;
        }


        public void Update(SchoolScheduleContext ctx)
        {
            throw new NotImplementedException();
        }

        public void Delete(SchoolScheduleContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}