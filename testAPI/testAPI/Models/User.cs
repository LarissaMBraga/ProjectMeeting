using System.ComponentModel.DataAnnotations;

namespace testAPI.Models
{
    public class User
    {
        [Key]
        public Guid User_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        // Relacionamento FK
        public ICollection<Meet> Meets { get; set; }

        // Constructor
        public User()
        {
            Meets = new HashSet<Meet>();
        }

    }
}