using System.Data.Entity.Infrastructure;

namespace EugeneDunin.SchoolSchedule.DataModule.Contexts
{
    public class AutomigrationSchoolScheduleDbContextFactory : IDbContextFactory<SchoolScheduleContext>
    {
        public SchoolScheduleContext Create()
        {
            return new SchoolScheduleContext(false);
        }
    }
}