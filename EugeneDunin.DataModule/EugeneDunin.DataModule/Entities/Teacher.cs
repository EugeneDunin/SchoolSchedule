using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.DataModule.Entities
{
    public class Teacher
    {
        public long TeacherId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string Patronymic { get; set; }
        public int StudyLoad { get; set; }

        public virtual Class Class { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}