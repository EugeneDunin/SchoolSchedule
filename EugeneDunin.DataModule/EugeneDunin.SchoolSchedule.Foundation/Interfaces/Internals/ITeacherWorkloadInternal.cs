using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    internal interface ITeacherWorkloadInternal: ITeacherWorkload
    {
        new string Name { get; set; }
        new string Surname { get; set; }
        new string Patronymic { get; set; }
        new string SubjectName { get; set; }
        new ICollection<IClassLoad> ClassLoads { get; set; }
    }
}