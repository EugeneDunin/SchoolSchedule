namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IClass: IEntity
    {
        int Number { get; }
        string Label { get; }
    }
}