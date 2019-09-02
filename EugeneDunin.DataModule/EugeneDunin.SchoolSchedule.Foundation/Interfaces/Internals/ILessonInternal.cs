using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    internal interface ILessonInternal: ILesson
    {
        new int LessonNumber { get; set; }
    }
}
