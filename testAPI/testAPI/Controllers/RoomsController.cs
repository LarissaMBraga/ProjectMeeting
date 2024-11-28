using Microsoft.AspNetCore.Mvc;
using testAPI.Data;
using testAPI.Dtos;
using testAPI.Models;

namespace testAPI.Controllers
{
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly EFDBContext _dbContext;

        public RoomsController(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] RoomCreateDto obj)
        {
            Room room = new Room();
            room.Room_id = Guid.NewGuid();
            room.Name = obj.Name;
            room.Capacity = obj.Capacity;
            room.Description = obj.Description;
            room.Available = obj.Available;


            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();

            return Ok(room);
        }

        [HttpGet]
        [Route("GetAllRooms")]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(_dbContext.Room.ToList());
        }

        [HttpGet]
        [Route("GetRoom/{id}")]
        public async Task<IActionResult> GetRoom(Guid id)
        {
            var room = await _dbContext.Room.FindAsync(id);

            if(room == null)
            {
                return NotFound(new { message = "room not found." });
            }

            return Ok(room);
        }

        [HttpPut]
        [Route("EditRoom/{id}")]
        public async Task<IActionResult> EditRoom([FromBody] RoomCreateDto obj, Guid id)
        {

            var room = await _dbContext.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound(new { message = "room not found." });
            }

            room.Name = obj.Name;
            room.Capacity = obj.Capacity;
            room.Description = obj.Description;
            room.Available = obj.Available;

            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "room updated successfully.", room });
        }

        [HttpDelete]
        [Route("DeleteRoom/{id}")]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {

            var room = await _dbContext.Room.FindAsync(id);

            if (room == null)
            {
                return NotFound(new { message = "room not found." });
            }

            _dbContext.Room.Remove(room);
            _dbContext.SaveChanges();

            return Ok(room);
        }
    }
}
