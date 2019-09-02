using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherScheduleProvider
    {
        ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId);
        ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId, DateTime start, DateTime end);
        ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName);
        ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName, DateTime start, DateTime end);
        ICollection<ITeacherSchedule> GetTeachersWorkLoad(DateTime start, DateTime end);
    }
}
