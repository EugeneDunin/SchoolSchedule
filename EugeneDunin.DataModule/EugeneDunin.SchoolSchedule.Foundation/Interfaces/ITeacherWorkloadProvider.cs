using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherWorkloadProvider
    {
        ICollection<ITeacherWorkload> GetTeacherWorkLoad(long teacherId);
        ICollection<ITeacherWorkload> GetTeacherWorkLoad(long teacherId, DateTime start, DateTime end);
        ICollection<ITeacherWorkload> GetTeachersWorkLoad(string subjectName);
        ICollection<ITeacherWorkload> GetTeachersWorkLoad(string subjectName, DateTime start, DateTime end);
        ICollection<ITeacherWorkload> GetTeachersWorkLoad(DateTime start, DateTime end);
    }
}