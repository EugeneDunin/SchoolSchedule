namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface ITeacherWorkloadFactory
    {
        ITeacherWorkload CreateTeacherWorkload<TInit>(TInit initializer) where  TInit : class;
    }
}
