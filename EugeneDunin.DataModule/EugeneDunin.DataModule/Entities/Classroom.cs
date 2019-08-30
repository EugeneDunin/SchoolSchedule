using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities
{
    public class Classroom
    {
        public long ClassroomId { get; set; }
        [Index("INDEX_UNICLASSROOM", Order = 1, IsUnique = true)]
        public int Number { get; set; }
        [Index("INDEX_UNICLASSROOM", Order = 2, IsUnique = true)]
        [StringLength(1)]
        public string Label { get; set; }


        public virtual ICollection<TeacherWorkloadSchedule> TeacherWorkloadSchedules { get; set; }
    }
}