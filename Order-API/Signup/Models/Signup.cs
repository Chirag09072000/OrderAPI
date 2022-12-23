using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Models
{
    public class Signup
    {
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [Key]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
