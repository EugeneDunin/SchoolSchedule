using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities
{
    public class TeacherSubject
    {
        public long TeacherSubjectId { get; set; }


        [Required]
        [Index("INDEX_UNI_TS", Order = 1, IsUnique = true)]
        [ForeignKey("Teacher")]
        public virtual long FkTeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Required]
        [Index("INDEX_UNI_TS", Order = 2, IsUnique = true)]
        [ForeignKey("Subject")]
        public virtual long FkSubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<TeacherWorkloadSchedule> TeacherWorkloadSchedules { get; set; }
    }
}