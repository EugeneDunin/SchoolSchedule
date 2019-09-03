using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherInfo: IEntity
    {
        string Name { get; }
        string Surname { get; }
        string Patronymic { get; }
        int StudyLoad { get; }
        string SubjectName { get; }
    }
}