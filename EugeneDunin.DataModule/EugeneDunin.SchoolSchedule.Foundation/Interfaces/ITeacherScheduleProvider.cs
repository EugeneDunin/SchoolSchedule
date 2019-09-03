using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherScheduleProvider
    {
        ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId);
        ICollection<ITeacherSchedule> GetTeacherSchedule(long teacherId, DateTime fromDate, DateTime toDate);
        ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName);
        ICollection<ITeacherSchedule> GetTeachersSchedule(string subjectName, DateTime fromDate, DateTime toDate);
        ICollection<ITeacherSchedule> GetTeachersWorkLoad(DateTime fromDate, DateTime toDate);
    }
}
