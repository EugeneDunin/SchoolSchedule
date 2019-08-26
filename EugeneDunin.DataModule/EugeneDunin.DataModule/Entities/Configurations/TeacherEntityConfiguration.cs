using System.Data.Entity.ModelConfiguration;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities.Configurations
{
    public class TeacherEntityConfiguration: EntityTypeConfiguration<Teacher>
    {
        public TeacherEntityConfiguration()
        {
            this.HasIndex(teacher => new { teacher.Name, teacher.Surname, teacher.Patronymic})
                .IsUnique(true);
        }
    }
}