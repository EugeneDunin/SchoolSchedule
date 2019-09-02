using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers
{
    public class TeacherFactoryInitializer
    {
        public Teacher Teacher { get; }
        public Subject Subject { get; }


        public TeacherFactoryInitializer(Teacher teacher, Subject subject)
        {
            Teacher = teacher;
            Subject = subject;
        }
    }
}