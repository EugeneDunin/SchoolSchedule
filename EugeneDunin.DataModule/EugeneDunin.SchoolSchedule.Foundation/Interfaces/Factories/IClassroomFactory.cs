namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface IClassroomFactory<in TInit>
    {
        IClassroom CreatClassroom(TInit initializer);
    }
}