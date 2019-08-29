using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.SchoolSchedule.DataModule.Entities
{
    public class TeacherWorkloadSchedule
    {
        public long TeacherWorkloadScheduleId { get; set; }
        public int StudyLoad { get; set; }
        [Index("INDEX_LESSON_TIME_CONFLICT", Order = 1, IsUnique = true)]
        public DayOfWeek DayOfWeek { get; set; }
        [Index("INDEX_LESSON_TIME_CONFLICT", Order = 2, IsUnique = true)]
        public int LessonNumber { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime FromDate { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime ToDate { get; set; }


        [Required]
        [ForeignKey("Teacher")]
        public virtual long FkTeacherSubjectId { get; set; }
        public virtual TeacherSubject TeacherSubject { get; set; }
    }
}