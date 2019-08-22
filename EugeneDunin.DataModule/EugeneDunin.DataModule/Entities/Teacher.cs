using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.DataModule.Entities
{
    public class Teacher
    {
        public virtual long TeacherId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Column("StudyLoad", TypeName = "TINYINT")]
        public int StudyLoad { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}