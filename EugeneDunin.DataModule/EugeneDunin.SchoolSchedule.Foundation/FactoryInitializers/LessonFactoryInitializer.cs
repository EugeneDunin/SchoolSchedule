using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers
{
    public class LessonFactoryInitializer
    {
        public TeacherWorkloadSchedule TeacherWorkloadSchedule { get; }
        public Class Subject { get; }


        public LessonFactoryInitializer(TeacherWorkloadSchedule teacherWorkloadSchedule, Class subject)
        {
            TeacherWorkloadSchedule = teacherWorkloadSchedule;
            Subject = subject;
        }
    }
}