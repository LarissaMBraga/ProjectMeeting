using System.ComponentModel.DataAnnotations;
using testAPI.Models;

namespace testAPI.Dtos
{
    public class RoomCreateDto
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Capacity { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; } = true;

    }


}
