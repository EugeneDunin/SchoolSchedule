namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface IClassFactory<in TInit>
    {
        IClass CreateClass(TInit initializer);
    }
}