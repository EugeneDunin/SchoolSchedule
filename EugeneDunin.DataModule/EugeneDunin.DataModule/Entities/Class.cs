using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities
{
    public class Class
    {
        [Index("INDEX_UNICLASS", Order = 1, IsUnique = true)]
        public int Number { get; set; }
        [Index("INDEX_UNICLASS", Order = 2, IsUnique = true)]
        [StringLength(1)]
        public string Label { get; set; }

        [Key]
        [ForeignKey("Teacher")]
        public virtual long ClassroomTeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}