using System.ComponentModel.DataAnnotations;

namespace testAPI.Models
{
    public class Room
    {
        [Key]
        public Guid Room_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; } = true;

        public ICollection<Meet> Meets { get; set; }

    }
}
