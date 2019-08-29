using EugeneDunin.SchoolSchedule.Foundation.Interfaces;

namespace EugeneDunin.SchoolSchedule.Foundation.Classes
{
    public class ClassFactory : IClassFactory<DataModule.Entities.Class>
    {
        public IClass CreateClass(DataModule.Entities.Class initializer)
        {
            return new Class() { Number = initializer.Number, Label = initializer.Label };
        }
    }
}