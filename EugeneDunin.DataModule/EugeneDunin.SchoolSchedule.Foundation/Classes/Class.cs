using EugeneDunin.SchoolSchedule.Foundation.Interfaces;

namespace EugeneDunin.SchoolSchedule.Foundation.Classes
{
    public class Class : IClass
    {
        public int Number { get; set; }
        public string Label { get; set; }
    }
}
