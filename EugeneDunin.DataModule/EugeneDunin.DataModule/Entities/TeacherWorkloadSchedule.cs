using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EugeneDunin.DataModule.Entities
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
        [ForeignKey("Teacher")]
        [Index("INDEX_SCHEDULE", Order = 1, IsUnique = true)]
        public virtual long FkTeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Required]
        [ForeignKey("Class")]
        [Index("INDEX_SCHEDULE", Order = 2, IsUnique = true)]
        public virtual long FkClassId { get; set; }
        public virtual Class Class { get; set; }

        [Required]
        [ForeignKey("Classroom")]
        public virtual long FkClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
    }
}