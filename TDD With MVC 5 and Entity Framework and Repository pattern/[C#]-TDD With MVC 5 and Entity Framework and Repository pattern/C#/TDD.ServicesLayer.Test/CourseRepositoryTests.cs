using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Entities.DAL;
using System.Linq;
using TDD.Entities.Models;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;

namespace TDD.ServicesLayer.Test
{
    [TestClass]
    public class CourseRepositoryTests
    {
        private Mock<SchoolContext> _mockCourseContext;
        private Mock<DbSet<Course>> _mockCourses;
        private CourseRepository _CourseRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockCourseContext = new Mock<SchoolContext>();// DB ref
            _mockCourses = new Mock<DbSet<Course>>();  // Entity ref
            _mockCourseContext.Setup(x => x.Courses).Returns(_mockCourses.Object); //setup
            _CourseRepository = new CourseRepository(_mockCourseContext.Object);  // repo
        }


        [TestCleanup]
        public void TestCleanup()
        {
            _mockCourseContext.VerifyAll();
        }

        [TestMethod]
        public void GetAllCourses_ExpectAllSCoursesReturned()
        {
            var stubData = (new List<Course>
            {
                new Course()
                {
                    
                    CourseID = 1,
                    Title= "maths"
                },
                new Course()
                {
                      
                    CourseID = 2,
                    Title= "science"
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockCourses);

            var actual = _CourseRepository.Get();//.GetAllStudents();

            CollectionAssert.AreEqual(stubData.ToList(), actual.ToList());
        }

        [TestMethod]
        public void AddStudent_Given_Course_ExpectCourseAdded()
        {
            var course = new Course()
            {               
                    Title= "English"
              
            };
            const int expectedID = 1;
            _mockCourseContext.Setup(x => x.SaveChanges()).Callback(() => course.CourseID = expectedID);

            int id = _CourseRepository.add(course);

            _mockCourses.Verify(x => x.Add(course), Times.Once);
            _mockCourseContext.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedID, id);
        }

        [TestMethod]
        public void GetCourse_Given_id_ExpectCourseReturned()
        {
            int id = 2;
            var stubData = (new List<Course>
            {
                new Course()
                {
                    CourseID = 1,
                 Title="Course ABC"
                },
                new Course()
                {
                    CourseID = 2,
                    Title = "DFDFDFD"
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockCourses);

            var actual = _CourseRepository.GetByID(id);

            Assert.AreEqual(stubData.ToList()[1], actual);
        }

        private void SetupTestData<T>(IQueryable<T> testData, Mock<DbSet<T>> mockDbSet) where T : class
        {
            mockDbSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator())
                .Returns((IEnumerator<Course>)testData.GetEnumerator());
        }
    }
}
