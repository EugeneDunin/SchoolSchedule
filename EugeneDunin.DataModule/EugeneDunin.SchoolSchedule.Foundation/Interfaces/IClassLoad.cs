namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IClassLoad: IEntity
    {
        int StudyLoadToClass { get; set; }
        IClass Class { get; }
    }
}