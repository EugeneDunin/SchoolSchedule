using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories;

namespace EugeneDunin.SchoolSchedule.Foundation.Lessons
{
    public class LessonFactory: ILessonFactory<LessonFactoryInitializer>
    {
        private readonly IClassFactory<Class> _classFactory;
        private readonly IClassroomFactory<Classroom> _classroomFactory;


        public LessonFactory(IClassFactory<Class> classFactory, IClassroomFactory<Classroom> classroomFactory)
        {
            _classFactory = classFactory;
            _classroomFactory = classroomFactory;
        }


        public ILesson CreateLesson(LessonFactoryInitializer initializer)
        {
            return new Lesson(initializer.TeacherWorkloadSchedule.TeacherWorkloadScheduleId)
            {
                Class = _classFactory.CreateClass(initializer.Class),
                DayOfWeek = initializer.TeacherWorkloadSchedule.DayOfWeek,
                LessonNumber = initializer.TeacherWorkloadSchedule.LessonNumber,
                Classroom = _classroomFactory.CreatClassroom(initializer.Classroom)
            };
        }
    }
}