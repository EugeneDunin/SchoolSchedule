using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.DataModule.Entities;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;

namespace EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads
{
    public class TeacherWorkloadFactory : ITeacherWorkloadFactory<TeacherWorkloadSchedule>
    {
        private readonly SchoolScheduleContext _context;
        private readonly IClassFactory<DataModule.Entities.Class> _classFactory;


        public TeacherWorkloadFactory(SchoolScheduleContext context, IClassFactory<DataModule.Entities.Class> classFactory)
        {
            _context = context;
            _classFactory = classFactory;
        }


        public ITeacherWorkload CreateTeacherWorkload(TeacherWorkloadSchedule initializer)
        {
            _context.Entry(initializer).Reference(i => i.Teacher).Load();
            _context.Entry(initializer.Teacher).Reference(t => t.Subjects).Load();
            _context.Entry(initializer).Reference(i => i.Class).Load();

            var teacher = initializer.Teacher;
            var Subjects = teacher.Subjects;
            var classLesson = _classFactory.CreateClass(initializer.Class);

            return new TeacherWorkload()
            {
                TeacherFullName = string.Format(@"{0} {1} {2}",teacher.Surname, teacher.Name, teacher.Patronymic),
                SubjectName = 
                StudyLoadToClass = initializer.StudyLoad,
                Class = initializer.Class
            };
        }
    }
}