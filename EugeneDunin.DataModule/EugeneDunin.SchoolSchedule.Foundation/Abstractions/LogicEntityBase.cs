using EugeneDunin.SchoolSchedule.DataModule.Contexts;

namespace EugeneDunin.SchoolSchedule.Foundation.Abstractions
{
    public abstract class LogicEntityBase
    {
        protected readonly SchoolScheduleContext Ctx;


        protected LogicEntityBase(SchoolScheduleContext ctx)
        {
            Ctx = ctx;
        }
    }
}