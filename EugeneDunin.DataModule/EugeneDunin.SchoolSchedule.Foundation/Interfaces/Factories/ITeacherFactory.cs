namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface ITeacherFactory<in TInit>
    {
        ITeacher CreateTeacher(TInit initializer);
    }
}