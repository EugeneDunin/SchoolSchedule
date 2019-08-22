using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.DataModule.Entities
{
    public class Class
    {
        public long ClassId { get; set; }
        [Index("INDEX_UNICLASS", IsClustered = true, IsUnique = true)]
        public int Number { get; set; }
        [Index("INDEX_UNICLASS", IsClustered = true, IsUnique = true)]
        [Column("Label", TypeName = "CHAR")]
        public char? Label { get; set; }

        [Required]
        [ForeignKey("Teacher")]
        public virtual long ClassroomTeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}