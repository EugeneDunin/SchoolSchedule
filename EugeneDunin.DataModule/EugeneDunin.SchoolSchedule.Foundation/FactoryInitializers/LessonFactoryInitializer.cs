using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers
{
    public struct LessonFactoryInitializer
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