namespace EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals
{
    internal interface IClassInternal: IClass
    {
        new int Number { get; set; }
        new string Label { get; set; }
    }
}
