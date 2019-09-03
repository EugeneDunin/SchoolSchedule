using EugeneDunin.SchoolSchedule.DataModule.Contexts;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IEntity: IId
    {
        void Update(SchoolScheduleContext ctx);
        void Delete(SchoolScheduleContext ctx);
    }
}