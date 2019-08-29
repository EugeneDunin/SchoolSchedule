using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities
{
    public class TeacherSubject
    {
        [Key]
        [Required]
        [ForeignKey("Teacher")]
        public virtual long FkTeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Key]
        [Required]
        [ForeignKey("Teacher")]
        public virtual long FkSubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<TeacherWorkloadSchedule> TeacherWorkloadSchedules { get; set; }
    }
}