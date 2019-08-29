using System;
using EugeneDunin.SchoolSchedule.DataModule.Contexts;
using EugeneDunin.SchoolSchedule.Foundation.Interfaces;
using EugeneDunin.SchoolSchedule.Foundation.TeacherWorkloads;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TeacherWorkloadProviderUnitTest
    {
        private readonly SchoolScheduleContext _schoolScheduleContext;
        private readonly ITeacherWorkloadProvider _teacherWorkloadProvider;
        private readonly ITeacherWorkloadFactory _teacherWorkloadFactory;

        public TeacherWorkloadProviderUnitTest()
        {
            _schoolScheduleContext = new SchoolScheduleContext();
            _teacherWorkloadFactory = new TeacherWorkloadFactory();
            _teacherWorkloadProvider = new TeacherWorkloadProvider(_schoolScheduleContext, _teacherWorkloadFactory);
        }

        [TestMethod]
        public void QueryTest()
        {

        }
    }
}
