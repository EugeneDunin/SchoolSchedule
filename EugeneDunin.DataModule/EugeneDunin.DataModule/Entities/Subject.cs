using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EugeneDunin.DataModule.Entities
{
    public class Subject
    {
        public long SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}