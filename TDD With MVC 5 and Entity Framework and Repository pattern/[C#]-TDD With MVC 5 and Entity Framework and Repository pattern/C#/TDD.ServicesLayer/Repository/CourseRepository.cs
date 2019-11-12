using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using TDD.Entities.Models;
using TDD.Entities.DAL;
using TDD.ServicesLayer;
using System.Data.Entity;
namespace TDD.ServicesLayer
{
    //public class CourseRepository : GenericRepository<Course>
    //{
    //    public CourseRepository(SchoolContext context)
    //        : base(context)
    //    {
    //    }
    //    public int UpdateCourseCredits(int multiplier)
    //    {
    //        return context.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);
    //    }
    //}

    public class CourseRepository : ICourseRepository
    {
         private SchoolContext context;

         public CourseRepository(SchoolContext context)
        {
            this.context = context;
        }
        public IEnumerable<Course> Get()
        {
            return context.Courses.ToList();//..ToList();
            //throw new NotImplementedException();
        }

        public Course GetByID(int courseID)
        {
            return context.Courses.Find(courseID);
        }

        public void Insert(Course course)
        {
            context.Courses.Add(course);           
        }

        public int add(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course.CourseID;
        }

        public void Delete(int courseID)
        {
            Course course = context.Courses.Find(courseID);
            context.Courses.Remove(course);
        }

        public void Update(Course course)
        {
            context.Entry(course).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
