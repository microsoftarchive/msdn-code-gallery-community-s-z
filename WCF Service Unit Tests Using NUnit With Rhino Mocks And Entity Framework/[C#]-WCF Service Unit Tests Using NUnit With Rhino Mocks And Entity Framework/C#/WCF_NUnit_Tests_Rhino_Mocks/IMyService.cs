using System.Collections.Generic;
using System.ServiceModel;

namespace WCF_NUnit_Tests_Rhino_Mocks
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        Course GetCourseById(int courseId);

        [OperationContract]
        List<Course> GetAllCourses();
    }
}
