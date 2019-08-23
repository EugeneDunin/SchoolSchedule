using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherSchedule : ITeacherWorkload
    {
        IClassroom Classroom { get; set; }
        ICollection<ILesson> Lessons { get; set;}
        DayOfWeek DayOfWeek { get; set; }
        ITeacher Teacher { get; set; }
    }
}