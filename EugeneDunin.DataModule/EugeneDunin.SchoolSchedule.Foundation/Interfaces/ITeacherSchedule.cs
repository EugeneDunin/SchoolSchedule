using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherSchedule: IEntity
    {
        IClassroom Classroom { get; set; }
        ICollection<ILesson> Lessons { get; }
        DayOfWeek DayOfWeek { get; }
        ITeacher Teacher { get; }
        IClass OwnClass { get; set; }
    }
}