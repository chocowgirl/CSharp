using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WebAPI.Mapper;
using WebAPI.Models;
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
        [ProducesResponseType(500)]
        public IActionResult Get(Guid id)
        {
            UserDTO model = _userService.Get(id).ToDTO();
            if (model is not null)
            {
                return Ok(model);
            }
            return NotFound(); // returns a 404 code
            //return StatusCode(404); //same as above said differently
        }

        //**********left off here


        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
