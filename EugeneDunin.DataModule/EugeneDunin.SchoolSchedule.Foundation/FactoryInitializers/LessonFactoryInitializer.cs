using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers
{
    public class LessonFactoryInitializer
    {
        public TeacherWorkloadSchedule TeacherWorkloadSchedule { get; }
        public Class Class { get; }
        public Classroom Classroom { get; }


        public LessonFactoryInitializer(
            TeacherWorkloadSchedule teacherWorkloadSchedule, Class cl, Classroom classroom)
        {
            TeacherWorkloadSchedule = teacherWorkloadSchedule;
            Class = cl;
            Classroom = classroom;
        }
    }
}