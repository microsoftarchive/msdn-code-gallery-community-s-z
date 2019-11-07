using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Entities.Models;

namespace TDD.ServicesLayer
{
   public interface ICourseRepository:IDisposable
    {
        IEnumerable<Course> Get();
        Course GetByID(int courseID);
        void Insert(Course course);
        void Delete(int courseID);
        void Update(Course course);
        void Save();
    }
}
