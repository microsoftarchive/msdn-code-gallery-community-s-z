using System;

namespace BackEnd
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDay { get; set; }
        public override string ToString()
        {
            return $"{Id}, {FirstName}, {LastName}, {Gender}, {BirthDay.ToShortDateString()} ";
        }

    }
}
