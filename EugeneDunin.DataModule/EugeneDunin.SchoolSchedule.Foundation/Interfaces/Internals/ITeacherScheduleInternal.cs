using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    public interface ITeacherScheduleInternal: ITeacherSchedule
    {
        new ICollection<ILesson> Lessons { get; set; }
        new ITeacherInfo TeacherInfo { get; set; }
        new IClass OwnClass { get; set; }
    }
}
