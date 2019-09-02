using System;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Abstractions;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using System.Data.Entity;
using System.Linq;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces.Internals;

namespace EugeneDunin.SchoolSchedule.Foundation.ClassLoads
{
    public class ClassLoad: LogicEntityBase, IClassLoadInternal
    {
        private readonly int StartStudyLoadToClass;

        public int StudyLoadToClass { get ; set; }
        public IClass Class { get; set; }
        public long Id { get; }


        public ClassLoad(SchoolScheduleContext ctx, long id) : base(ctx)
        {
            Id = id;
            StartStudyLoadToClass = StudyLoadToClass;
        }


        public void Update()
        {
            if (StudyLoadToClass != StartStudyLoadToClass)
            {
                var currStudyLoad = Ctx.TeacherWorkloadSchedules.Where(tws =>
                    tws.FkTeacherSubjectId == Ctx.TeacherWorkloadSchedules.Find(Id).FkTeacherSubjectId
                ).Sum(tws => tws.StudyLoad);

                var twsRecord = Ctx.TeacherWorkloadSchedules
                    .Include(tws => tws.TeacherSubject.Teacher)
                    .First(tws => tws.TeacherWorkloadScheduleId == Id);

                var maxStudyLoad = twsRecord.TeacherSubject.Teacher.StudyLoad;

                if (maxStudyLoad >= (currStudyLoad - StartStudyLoadToClass) + StudyLoadToClass)
                {
                    twsRecord.StudyLoad = StudyLoadToClass;
                }
                else
                {
                    throw new ArgumentException(
                        $"Study load to class have too mach value, the max accepted value is {maxStudyLoad - currStudyLoad}." +
                        $" Workload of teacher {maxStudyLoad}"
                    );
                }
            }

            if (StudyLoadToClass == 0)
            {
                Ctx.TeacherWorkloadSchedules.Find(Id).StudyLoad = 0;
            }
        }

        public void Delete()
        {
            Ctx.TeacherWorkloadSchedules.Remove(Ctx.TeacherWorkloadSchedules.Find(Id));
        }
    }
}