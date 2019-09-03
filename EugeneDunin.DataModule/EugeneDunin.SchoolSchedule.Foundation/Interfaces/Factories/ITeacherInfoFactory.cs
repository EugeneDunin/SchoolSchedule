namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface ITeacherInfoFactory<in TInit>
    {
        ITeacherInfo CreateTeacher(TInit initializer);
    }
}