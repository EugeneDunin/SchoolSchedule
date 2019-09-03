using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.Foundation.FactoryInitializers;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories;

namespace EugeneDunin.SchoolSchedule.Foundation.ClassLoads
{
    public class ClassLoadFactory: IClassLoadFactory<ClassLoadFactoryInitializer>
    {
        private readonly IClassFactory<Class> _classFactory;


        public ClassLoadFactory(IClassFactory<Class> classFactory)
        {
            _classFactory = classFactory;
        }


        public IClassLoad CreateClassLoad(ClassLoadFactoryInitializer initializer)
        {
            return new ClassLoad(initializer.TeacherWorkloadSchedule.TeacherWorkloadScheduleId)
            {
                StudyLoadToClass = initializer.TeacherWorkloadSchedule.LessonNumber,
                Class = _classFactory.CreateClass(initializer.Class)
            };
        }
    }
}