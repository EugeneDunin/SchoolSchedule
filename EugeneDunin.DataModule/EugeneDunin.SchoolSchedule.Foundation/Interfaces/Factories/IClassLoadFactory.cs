namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Factories
{
    public interface IClassLoadFactory<in TInit>
    {
        IClassLoad CreateClassLoad(TInit initializer);
    }
}