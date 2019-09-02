namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IEntity: IId
    {
        void Update();
        void Delete();
    }
}
