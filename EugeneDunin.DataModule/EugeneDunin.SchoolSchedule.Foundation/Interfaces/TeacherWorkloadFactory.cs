namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherWorkloadFactory<TInit>
    {
        ITeacherWorkload CreateTeacherWorkload(TInit initializer);
    }
}
