using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 10)]
        public string Address { get; set; }

    }
}