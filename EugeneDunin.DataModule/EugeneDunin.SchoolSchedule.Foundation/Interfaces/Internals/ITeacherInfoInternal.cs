namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    internal interface ITeacherInfoInternal: ITeacherInfo
    {
        new string Name { get; set; }
        new string Surname { get; set; }
        new string Patronymic { get; set; }
        new int StudyLoad { get; set;}
        new string SubjectName { get; set; }
    }
}