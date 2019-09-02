using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Abstractions;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals;

namespace EugeneDunin.SchoolSchedule.Foundation.Classes
{
    public class Class : ContextInitBase, IClassInternal
    {
        public long Id { get; }
        public int Number { get; set; }
        public string Label { get; set; }


        public Class(SchoolScheduleContext ctx, long id) : base(ctx)
        {
            Id = id;
        }
    }
}