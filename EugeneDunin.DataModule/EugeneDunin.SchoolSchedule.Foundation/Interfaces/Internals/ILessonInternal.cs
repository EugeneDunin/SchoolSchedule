using System;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    internal interface ILessonInternal: ILesson
    {
        new int LessonNumber { get; set; }
        new DayOfWeek DayOfWeek { get; set; }
    }
}