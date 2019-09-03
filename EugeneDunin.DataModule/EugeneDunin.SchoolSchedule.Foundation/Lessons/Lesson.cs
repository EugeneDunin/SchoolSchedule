using System;
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
            throw new NotImplementedException();
        }

        public void Delete(SchoolScheduleContext ctx)
        {
            throw new NotImplementedException();
        }
    }
}