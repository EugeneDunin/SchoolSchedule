namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    internal interface IClassLoadInternal: IClassLoad
    {
        new int StudyLoadToClass { get; set; }
        new IClass Class { get; set; }
    }
}
