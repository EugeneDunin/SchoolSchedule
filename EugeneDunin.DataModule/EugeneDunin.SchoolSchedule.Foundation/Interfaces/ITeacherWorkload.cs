using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherWorkload: IEntity
    {
        string Name { get; }
        string Surname { get; }
        string Patronymic { get; }
        string SubjectName { get; }
        ICollection<IClassLoad> ClassLoads { get; }
    }
}