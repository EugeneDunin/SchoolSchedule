using EugeneDunin.SchoolSchedule.DataModule.Entities;

namespace EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers
{
    public struct ClassLoadFactoryInitializer
    {
        public TeacherWorkloadSchedule TeacherWorkloadSchedule { get; }
        public Class Class { get; }


        public ClassLoadFactoryInitializer(
            TeacherWorkloadSchedule teacherWorkloadSchedule, Class cl)
        {
            TeacherWorkloadSchedule = teacherWorkloadSchedule;
            Class = cl;
        }
    }
}