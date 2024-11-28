using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Data;
using testAPI.Dtos;
using testAPI.Models;

namespace testAPI.Controllers
{
    [ApiController]
    public class MeetsController : ControllerBase
    {
        private readonly EFDBContext _dbContext;

        public MeetsController(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CreateMeet")]
        public async Task<IActionResult> CreateMeet(
            [FromBody] MeetCreateDto obj,
            [FromHeader] Guid userId,
            [FromHeader] Guid roomId)
        {

            if (!Guid.TryParse(userId.ToString(), out Guid createdByGuid))
            {
                return BadRequest(new { error = "The field 'Created_by' must be a valid GUID." });
            }
            if (!Guid.TryParse(roomId.ToString(), out Guid room_idGuid))
            {
                return BadRequest(new { error = "The field 'Room_id' must be a valid GUID." });
            }

            Meet meet = new Meet();
            meet.Meet_id = Guid.NewGuid();
            meet.Title = obj.Title;
            meet.Description = obj.Description;
            meet.Start_date = obj.Start_date;
            meet.End_date = obj.End_date;
            meet.Room_id = room_idGuid;
            meet.Meeting_link = obj.Meeting_link;
            meet.Created_by = createdByGuid;


            _dbContext.Meet.Add(meet);
            _dbContext.SaveChanges();

            return Ok(meet);
        }

        [HttpGet]
        [Route("GetAllMeets")]
        public async Task<IActionResult> GetAllMeets()
        {
            return Ok(_dbContext.Meet.ToList());
        }

        [HttpGet]
        [Route("GetMeet/{id}")]
        public async Task<IActionResult> GetMeet(Guid id)
        {
            var meet = await _dbContext.Meet.FindAsync(id);

            if (meet == null)
            {
                return NotFound(new { message = "meet not found." });
            }

            return Ok(meet);
        }

        [HttpDelete]
        [Route("DeleteMeet/{id}")]
        public async Task<IActionResult> DeleteMeet(Guid id)
        {

            var meet = await _dbContext.Meet.FindAsync(id);

            if (meet == null)
            {
                return NotFound(new { message = "meet not found." });
            }

            _dbContext.Meet.Remove(meet);
            _dbContext.SaveChanges();

            return Ok(meet);
        }

    }
}
