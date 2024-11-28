using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using testAPI.Data;
using testAPI.Models;

namespace testAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EFDBContext _dbContext;

        public UserController(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto obj)
        {
            User user = new User();
            user.User_id = Guid.NewGuid();
            user.Name = obj.Name;
            user.Email = obj.Email;
            user.Password = obj.Password;


            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                // Verificar se o email foi fornecido
                if (string.IsNullOrEmpty(loginDto.Email))
                {
                    return BadRequest(new { message = "Email is required." });
                }

                // Verificar se a senha foi fornecida
                if (string.IsNullOrEmpty(loginDto.Password))
                {
                    return BadRequest(new { message = "Password is required." });
                }

                // Procurar o usuário no banco de dados pelo email
                var user = await _dbContext.User.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

                // Verificar se o usuário existe
                if (user == null)
                {
                    return Unauthorized(new { message = "Invalid email or password." });
                }

                // Verificar se a senha está correta
                if (user.Password != loginDto.Password)
                {
                    return Unauthorized(new { message = "Invalid email or password." });
                }

                // Retornar sucesso com os detalhes do usuário (sem expor a senha)
                return Ok(new
                {
                    UserId = user.User_id,
                    Name = user.Name,
                    Email = user.Email
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet]
        [Route("GetAllUser")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(_dbContext.User.ToList());
        }

        [HttpGet]
        [Route("GetUser/{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {

            var user = await _dbContext.User.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            return Ok(user);
        }

    }
}
