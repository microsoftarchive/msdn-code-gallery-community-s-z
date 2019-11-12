using System.Collections.Generic;
using System.Linq;

namespace WCF_NUnit_Tests_Rhino_Mocks
{
    public class MyService : IMyService
    {
        private static MyEntity _myContext;
        private static IMyService _myIService;

        public MyService()
        {
            
        }

        public MyService(IMyService myIService)
        {
            _myContext = new MyEntity();
            _myIService = myIService;
        }
        public Course GetCourseById(int courseId)
        {
            var crse = _myContext.Courses.FirstOrDefault(dt => dt.CourseID == courseId);
            return crse;
        }

        public List<Course> GetAllCourses()
        {
            var courses = (from dt in _myContext.Courses select dt).ToList();
            return courses;
        }
    }
}
