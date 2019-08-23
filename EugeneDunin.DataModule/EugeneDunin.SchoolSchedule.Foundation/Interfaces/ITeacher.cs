using System.Collections.Generic;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacher
    {
        string Name { get; }
        string Surname { get; }
        string Patronymic { get; }
        int StudyLoad { get; }
        HashSet<string> Subjects { get; }
    }
}