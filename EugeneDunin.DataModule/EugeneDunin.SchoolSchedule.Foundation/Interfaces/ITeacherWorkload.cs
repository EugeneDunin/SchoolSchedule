namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherWorkload
    {
        string TeacherFullName { get; set; }
        string SubjectName { get; set; }
        int StudyLoadToClass { get; set; }
        IClass Class { get; set; }
    }
}