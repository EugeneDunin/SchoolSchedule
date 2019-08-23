using System.Data.Entity.ModelConfiguration;
using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.DataModule.Entities.Configurations
{
    class TeacherEntityConfiguration: EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration()
        {

        }
    }
}