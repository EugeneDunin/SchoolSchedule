using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.DataModule.Entities
{
    public class TeacherWorkloadSchedule
    {
        public long TeacherScheduleId { get; set; }
        public int StudyLoad { get; set; }
        [Index("INDEX_LESSON_TIME_CONFLICT", IsClustered = true, IsUnique = true)]
        public DayOfWeek DayOfWeek { get; set; }
        [Index("INDEX_LESSON_TIME_CONFLICT", IsClustered = true, IsUnique = true)]
        public int LessonNumber { get; set; }

        [Required]
        [Index("INDEX_SCHEDULE", IsClustered = true, IsUnique = true)]
        public virtual long TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Required]
        [Index("INDEX_SCHEDULE", IsClustered = true, IsUnique = true)]
        public virtual long ClassId { get; set; }
        public virtual Class Class { get; set; }

        [Required]
        public virtual long ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}