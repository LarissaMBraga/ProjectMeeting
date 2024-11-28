using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testAPI.Models
{
    public class Meet
    {
        [Key]
        public Guid Meet_id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title{ get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start_date { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End_date { get; set; }

        //FK by Room
        [ForeignKey("Room")]
        public Guid Room_id { get; set; }

        public string Meeting_link { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created_in { get; set; } = DateTime.Now;

        //FK by User
        [ForeignKey("User")]
        public Guid Created_by { get; set; }

        public Room Room { get; set; }
        public User User { get; set; }

    }
}
