using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using testAPI.Models;

namespace testAPI.Dtos
{
    public class MeetCreateDto
    {


        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start_date { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End_date { get; set; }

        public string Meeting_link { get; set; }


    }
}
