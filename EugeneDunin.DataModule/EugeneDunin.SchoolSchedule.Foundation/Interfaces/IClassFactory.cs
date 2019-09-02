using EugeneDunin.SchoolSchedule.DataModule.Contexts;

namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IClassFactory<in TInit>
    {
        IClass CreateClass(SchoolScheduleContext ctx, TInit initializer);
    }
}