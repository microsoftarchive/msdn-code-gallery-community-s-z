using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompositeKeySupport.Models
{
    public class PeopleRepository
    {
        public static List<Person> _people = new List<Person>();
        static PeopleRepository()
        {
            _people.Add(new Person { FirstName = "Kate", LastName = "Jones", Age = 5 });
            _people.Add(new Person { FirstName = "Lewis", LastName = "James", Age = 6 });
            _people.Add(new Person { FirstName = "Carlos ", LastName = "Park", Age = 7 });
        }

        public IEnumerable<Person> Get()
        {
            return _people;
        }

        public void Add(Person p)
        {
            _people.Add(p);
        }

        public Person Get(string firstName, string lastName)
        {
            return _people.Where(p => p.FirstName == firstName && p.LastName == lastName).FirstOrDefault();
        }

        public Person Remove(string firstName, string lastName)
        {
            var p = Get(firstName, lastName);
            if (p == null)
                return null;
            _people.Remove(p);
            return p;
        }

        public void UpdateOrAdd(Person person)
        {
            Remove(person.FirstName, person.LastName);
            Add(person);            
        }
    }
}