using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities
{
    public class Subject
    {
        public long SubjectId { get; set; }
        [Required]
        [StringLength(50)]
        [Index("INDEX_UNICSUBJECTNAME", 1, IsUnique = true)]
        public string SubjectName { get; set; }


        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}