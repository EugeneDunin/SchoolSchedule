using EugeneDunin.SchoolSchedule.DataModule.Contexts;

namespace EugeneDunin.SchoolSchedule.Foundation.Abstractions
{
    public abstract class ContextInitBase
    {
        protected readonly SchoolScheduleContext Ctx;


        protected ContextInitBase(SchoolScheduleContext ctx)
        {
            Ctx = ctx;
        }
    }
}