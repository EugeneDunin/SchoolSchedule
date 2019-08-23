namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ILesson
    {
        IClass Class { get; }
        int LessonNumber { get; }
    }
}