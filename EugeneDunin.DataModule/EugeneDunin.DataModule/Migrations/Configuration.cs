namespace EugeneDunin.DataModule.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EugeneDunin.DataModule.Contexts.SchoolScheduleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EugeneDunin.DataModule.Contexts.SchoolScheduleContext";
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EugeneDunin.DataModule.Contexts.SchoolScheduleContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
