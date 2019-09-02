using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;

namespace EugeneDunin.SchoolSchedule.Foundation.Classes
{
    public class ClassFactory : IClassFactory<DataModule.Entities.Class>
    {
        public IClass CreateClass(SchoolScheduleContext ctx, DataModule.Entities.Class initializer)
        {
            return new Class(ctx, initializer.ClassId) { Number = initializer.Number, Label = initializer.Label };
        }
    }
}