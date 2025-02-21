using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebAPI.Mapper;
using WebAPI.Models.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<User> _userService;

        public UserController(IUserRepository<User> userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType<IEnumerable<UserDTO>>(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<UserDTO> model = _userService.Get().Select(bll => bll.ToDTO());
                return Ok(model);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [ProducesResponseType<UserDTO>(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Get(Guid id)
        {
            try
            {
                UserDTO model = _userService.Get(id).ToDTO();
                return Ok(model);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType<UserDTO>(201)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] UserPostDTO value)
        {
            try
            {
                Guid id = _userService.Insert(value.ToBLL());
                UserDTO model = _userService.Get(id).ToDTO();
                return CreatedAtAction(nameof(Get), new { id }, model);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [ProducesResponseType<UserDTO>(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid id, [FromBody] UserPutDTO value)
        {
            try
            {
                UserDTO model = _userService.Get(id).ToDTO();
                _userService.Update(id, value.ToBLL());
                model = _userService.Get(id).ToDTO();
                return CreatedAtAction(nameof(Get), new { id }, model);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                UserDTO model = _userService.Get(id).ToDTO();
                _userService.Delete(id);
                return NoContent();
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }

        [HttpPost("CheckPassword")]
        [ProducesResponseType<UserDTO>(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public IActionResult CheckPassword([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                Guid id = _userService.CheckPassword(email, password);
                UserDTO model = _userService.Get(id).ToDTO();
                return Ok(model);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
