using EugeneDunin.SchoolSchedule.DataModule.Contexts;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface IClassFactory<in TInit>
    {
        IClass CreateClass(SchoolScheduleContext ctx, TInit initializer);
    }
}