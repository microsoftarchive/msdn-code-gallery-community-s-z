using System;

namespace RegistrationForm.Models
{
    public class Registration
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string UserName { get; set; }
    }
}