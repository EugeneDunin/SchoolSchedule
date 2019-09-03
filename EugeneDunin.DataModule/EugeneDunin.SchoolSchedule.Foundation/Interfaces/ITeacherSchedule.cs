using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherSchedule: IEntity
    {
        ICollection<ILesson> Lessons { get; }
        ITeacher Teacher { get; }
        IClass OwnClass { get; set; }
    }
}