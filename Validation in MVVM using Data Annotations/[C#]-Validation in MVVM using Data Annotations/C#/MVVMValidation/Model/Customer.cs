using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMValidation.CustomValidationAttributes;
using MVVMValidation.Notification;

namespace MVVMValidation.Model
{
    public class Customer : PropertyChangedNotification
    {
        [Unqiue(ErrorMessage = "Duplicate Id. Id already exists")]
        [Required(ErrorMessage = "Id is Required")]
        public int Id
        {
            get { return GetValue(() => Id); }
            set { SetValue(() => Id, value); }
        }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Name exceeded 50 letters")]
        [ExcludeChar("/.,!@#$%", ErrorMessage = "Name contains invalid letters")]
        public string Name
        {
            get { return GetValue(() => Name); }
            set { SetValue(() => Name, value); }
        }

        [Range(1, 100, ErrorMessage = "Age should be between 1 to 100")]
        public int Age
        {
            get { return GetValue(() => Age); }
            set { SetValue(() => Age, value); }
        }

        public Gender Gender
        {
            get { return GetValue(() => Gender); }
            set { SetValue(() => Gender, value); }
        }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email Address is Invalid")]
        public string Email
        {
            get { return GetValue(() => Email); }
            set { SetValue(() => Email, value); }
        }

        [Required(ErrorMessage = "Repeat Email address is required")]
        [Compare("Email", ErrorMessage = "Email Address does not match")]
        public string RepeatEmail
        {
            get { return GetValue(() => RepeatEmail); }
            set { SetValue(() => RepeatEmail, value); }
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
