using System;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ILesson: IEntity
    {
        IClass Class { get; set; }
        int LessonNumber { get; }
        DayOfWeek DayOfWeek { get; }
        IClassroom Classroom { get; set; }
    }
}