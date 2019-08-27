using System.Data.Entity.Infrastructure;

namespace EugeneDunin.SchoolSchedule.DataModule.Contexts
{
    public class SchoolScheduleRecreateDBContextFactory : IDbContextFactory<SchoolScheduleContext>
    {
        public SchoolScheduleContext Create()
        {
            return new SchoolScheduleContext(true);
        }
    }
}