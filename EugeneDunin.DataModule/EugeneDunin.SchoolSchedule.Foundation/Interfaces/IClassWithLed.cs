namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IClassWithLed : IClass
    {
        ITeacher ClassLed { get; }
    }
}