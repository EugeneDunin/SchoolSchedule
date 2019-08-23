using EugeneDunin.SchoolSchedule.Foundation.Interfaces;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads
{
    public class TeacherWorkload : ITeacherWorkload
    {
        public string TeacherFullName { get; set; }
        public string SubjectName { get; set; }
        public int StudyLoadToClass { get; set; }
        public IClass Class { get; set; }
    }
}
