


using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }

        /// <summary>
        /// (?=.*[A-Za-z]): It checks if the string contains at least one letter (uppercase or lowercase) 
        /// (?=.*\d): This is another positive lookahead assertion that checks if the string contains at least one digit (\d)
        /// (?=.*[@$!%*#?&]): This is a positive lookahead assertion that checks if the string contains at least one special character from the character class [@$!%*#?&].
        /// [A-Za-z\d@$!%*#?&]{8,20}: This is the actual character matching part of the regex. It matches a sequence of characters that can be alphanumeric (letters and digits) or any of the special characters @$!%*#?&.
        /// The {8,20} specifies that the length of the matched sequence must be between 8 and 20 characters.
        /// $: This anchors the regex to the end of the string, ensuring that the entire string is matched by the regex.
        /// </summary>

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,20}$",
            ErrorMessage = "Password must be between 8 and 20 characters and contain at least one letter, one number, and one special character.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        [Range(1, 100000, ErrorMessage = "Salary must be between 0 and 100000.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\+?\d{1,3}[- .]?\(?\d{1,3}\)?[- .]?\d{1,4}[- .]?\d{1,4}$",
            ErrorMessage = "Invalid phone number.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [Url(ErrorMessage = "Invalid URL.")]
        public string? Website { get; set; }
    }
}
