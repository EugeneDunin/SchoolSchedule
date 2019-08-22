using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.DataModule.Entities
{
    public class Classroom
    {
        public long ClassroomId { get; set; }
        [Index("INDEX_UNICLASSROOM", IsClustered = true, IsUnique = true)]
        public int Number { get; set; }
        [Index("INDEX_UNICLASSROOM", IsClustered = true, IsUnique = true)]
        [Column("Label",TypeName = "CHAR")]
        public char? Label { get; set; }

        public virtual ICollection<TeacherWorkloadSchedule> TeacherWorkloadSchedule { get; set; }
    }
}