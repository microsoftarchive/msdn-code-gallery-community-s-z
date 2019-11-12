using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Entities.DAL;
using TDD.Entities.Models;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
namespace TDD.ServicesLayer.Test
{
    [TestClass]
    public class StudentRepositoryTests
    {
        private Mock<SchoolContext> _mockStudentContext;
        private Mock<DbSet<Student>> _mockStudents;
        private StudentRepository _StudentRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            _mockStudentContext = new Mock<SchoolContext>();
            _mockStudents = new Mock<DbSet<Student>>();
            _mockStudentContext.Setup(x => x.Students).Returns(_mockStudents.Object);
            _StudentRepository = new StudentRepository(_mockStudentContext.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _mockStudentContext.VerifyAll();
        }

        [TestMethod]
        public void GetAllStudents_ExpectAllStudentsReturned()
        {
            var stubData = (new List<Student>
            {
                new Student()
                {
                    
                    ID = 1,
                    FirstMidName = "John",                    
                    LastName = "Doe"
                },
                new Student()
                {
                    ID = 2,
                    FirstMidName = "Jane",
                    LastName = "Doe"
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockStudents);

            var actual = _StudentRepository.GetStudents() ;//.GetAllStudents();

            CollectionAssert.AreEqual(stubData.ToList(), actual.ToList());
        }

        [TestMethod]
        public void AddStudent_Given_Student_ExpectStudentAdded()
        {
            var Student = new Student()
            {
                FirstMidName = "John",
                LastName = "Doe"
            };
            const int expectedID = 1;
            _mockStudentContext.Setup(x => x.SaveChanges()).Callback(() => Student.ID = expectedID);

            int id = _StudentRepository.AddStudent(Student);

            _mockStudents.Verify(x => x.Add(Student), Times.Once);
            _mockStudentContext.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(expectedID, id);
        }

        [TestMethod]
        public void GetStudent_Given_id_ExpectStudentReturned()
        {
            int id = 2;
            var stubData = (new List<Student>
            {
                new Student()
                {
                    ID = 1,
                    FirstMidName = "John",
                    LastName = "Doe"
                },
                new Student()
                {
                    ID = 2,
                    FirstMidName = "Jane",
                    LastName = "Doe"
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockStudents);

            var actual = _StudentRepository.GetStudentByID(id);

            Assert.AreEqual(stubData.ToList()[1], actual);
        }

        [TestMethod]
        public void EditStudent_Given_Student_ExpectExistingStudentUpdated()
        {
            var stubData = (new List<Student>
            {
                new Student()
                {
                    ID = 1,
                    FirstMidName = "John",
                    LastName = "Doe"
                },
                new Student()
                {
                    ID = 2,
                    FirstMidName = "Jane",
                    LastName = "Doe"
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockStudents);
            var Student = new Student()
            {
                ID = 1,
                FirstMidName = "Ted",
                LastName = "Smith"           
            };
            _StudentRepository.UpdateStudent(Student);
            var actualStudent = _mockStudents.Object.First();
            Assert.AreEqual(Student.ID, actualStudent.ID);
            Assert.AreEqual(Student.FirstMidName, actualStudent.FirstMidName);
            Assert.AreEqual(Student.LastName, actualStudent.LastName);
           _mockStudentContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteStudent_Given_id_ExpectStudentDeleted()
        {
            var stubData = (new List<Student>
            {
                new Student()
                {
                    ID = 1,
                    FirstMidName = "John",
                    LastName = "Doe"
                },
                new Student()
                {
                    ID = 2,
                    FirstMidName = "Jane",
                    LastName = "Doe"
                }
            }).AsQueryable();
            SetupTestData(stubData, _mockStudents);
            var Student = stubData.First();

            _StudentRepository.DeleteStudent(1);
            _mockStudents.Verify(x => x.Remove(Student), Times.Once);
            _mockStudentContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        private void SetupTestData<T>(IQueryable<T> testData, Mock<DbSet<T>> mockDbSet) where T : class
        {
            mockDbSet.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(testData.Provider);
            mockDbSet.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(testData.Expression);
            mockDbSet.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(testData.ElementType);
            mockDbSet.As<IQueryable<Student>>().Setup(m => m.GetEnumerator())
                .Returns((IEnumerator<Student>)testData.GetEnumerator());
        }

       
    }
}
