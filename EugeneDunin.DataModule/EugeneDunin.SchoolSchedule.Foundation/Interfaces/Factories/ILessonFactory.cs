namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface ILessonFactory<in TInit>
    {
        ILesson CreateLesson(TInit initializer);
    }
}