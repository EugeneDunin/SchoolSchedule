using System.Data.Entity.Migrations;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;

namespace EugeneDunin.SchoolSchedule.DataModule.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EugeneDunin.DataModule.Contexts.SchoolScheduleContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolScheduleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}