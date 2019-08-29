namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces
{
    public interface IClassFactory<TInit>
    {
        IClass CreateClass(TInit initializer);
    }
}