using System.ComponentModel.DataAnnotations;

namespace testAPI.Models
{
    public class UserCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class LoginDto
    {

        public string Email { get; set; }

        public string Password { get; set; }


    }
}