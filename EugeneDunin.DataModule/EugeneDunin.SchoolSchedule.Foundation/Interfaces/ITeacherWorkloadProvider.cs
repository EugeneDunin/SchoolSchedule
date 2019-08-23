using System;
using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherWorkloadProvider
    {
        ICollection<ITeacherWorkload> GetTecherWorkLoad(long teacherId, DateTime start, DateTime end);
        ICollection<ITeacherWorkload> GetTechersWorkLoad(DateTime start, DateTime end);
    }
}
