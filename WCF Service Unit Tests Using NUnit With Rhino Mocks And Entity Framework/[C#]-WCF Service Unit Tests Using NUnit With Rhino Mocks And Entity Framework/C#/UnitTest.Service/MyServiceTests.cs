using NUnit.Framework;
using Rhino.Mocks;
using WCF_NUnit_Tests_Rhino_Mocks;

namespace UnitTest.Service
{
    [TestFixture]
    public class MyServiceTests
    {
        private static MyService _myService;
        private IMyService _myIservice;
        [OneTimeSetUp]
        public void SetUp()
        {
            _myIservice = MockRepository.GenerateMock<IMyService>();
            _myService = new MyService(_myIservice);
            
        }

        [TearDown]
        public void Clean()
        {
            
        }

        [Test(Description = "A test to check whether the returned value is null")]
        public void GetCourseById_Return_NotNull_Pass()
        {
            //Set Up
            var crs = new Course
            {
                CourseID = 1,
                CourseName = "C#",
                CourseDescription = "Learn course in 7 days"
            };
            _myIservice.Stub(dt => dt.GetCourseById(1)).IgnoreArguments().Return(crs);

            //Act
            crs = _myService.GetCourseById(1);

            //Assert
            Assert.IsNotNull(crs,"The returned value is null");
        }

        [Test(Description = "A test to check we get all the courses")]
        public void GetAllCourses_Return_List_Count_Pass()
        {
            //Act
            var crs = _myService.GetAllCourses();

            //Assert
            Assert.AreEqual(4, crs.Count,"The count of retrieved data doesn't match");
            _myIservice.VerifyAllExpectations();
        }

    }
}
