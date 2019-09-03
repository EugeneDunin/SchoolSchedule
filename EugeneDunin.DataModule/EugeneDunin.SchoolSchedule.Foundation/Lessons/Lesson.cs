using System;
using System.Data.Entity;
using System.Linq;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals;

namespace EugeneDunin.SchoolSchedule.Foundation.Lessons
{
    public class Lesson: ILessonInternal
    {
        public long Id { get; }
        public IClass Class { get; set; }
        public int LessonNumber { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public IClassroom Classroom { get; set; }


        public Lesson(long id)
        {
            Id = id;
        }


        public void Update(SchoolScheduleContext ctx)
        {
            var twsRecord = ctx.TeacherWorkloadSchedules
                .Include(tws => tws.Classroom)
                .Include(tws => tws.Class)
                .First(tws => tws.TeacherWorkloadScheduleId == Id);

            twsRecord.Class.Number = Class.Number;
            twsRecord.Class.Label = Class.Label;

            twsRecord.Classroom.Number = Classroom.Number;
            twsRecord.Classroom.Label = Classroom.Label;
        }

        public void Delete(SchoolScheduleContext ctx)
        {
            ctx.TeacherWorkloadSchedules.Remove(ctx.TeacherWorkloadSchedules.Find(Id));
        }
    }
}