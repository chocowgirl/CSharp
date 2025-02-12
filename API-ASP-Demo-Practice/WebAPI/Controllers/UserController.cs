using BLL.Entities;
using Common.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
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
        [ProducesResponseType(404)]
        public IActionResult Get(Guid id)
        {
            UserDTO model = _userService.Get(id).ToDTO();
            //if (model is null) throw new ArgumentOutOfRangeException(nameof(id)) <-- b/c we have the check for nullity elsewhere
            {
                return Ok(model);
            }
            Catc
            return NotFound(); // returns a 404 code
            //return StatusCode(404); //same as above said differently
        }



        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType<UserDTO>(201)] //response meaning yep, thing was created
        [ProducesResponseType(415)] //response meaning the expected input was not executed w success (checkMDNdocs later)
        public IActionResult Post(UserPostDTO user) //instead of user here SL used "value"
        {
            try
            {
                if (user.Last_Name == "string" || user.First_Name == "string") throw new ArgumentException(nameof(user));
                Guid id = _userService.Insert(user.ToBLL());//Insert function returns Guid of object inserted
                UserDTO model = _userService.Get(id).ToDTO();//id - we take the same id of the object inserted, and we cast to UserDTO to be able to show w/o password
                return CreatedAtAction(nameof(Get), new { id }, model);//if positive response, get the id of the newly posted user and show as DTO(model)
            }
            catch (Exception)
            {
                return StatusCode(415);
            }
        }


        // PUT api/<UserController>/5
        [HttpPut("{toto}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType<UserDTO>(201)]

        public IActionResult Put(Guid id, UserPutDTO user)
        {
            try
            {
                UserDTO oldValueModel = _userService.Get(id).ToDTO(); //Go get the object that you want to modify
                if (oldValueModel is null) throw new ArgumentOutOfRangeException(nameof(id));
                _userService.Update(id, user.ToBLL());
                UserDTO changedmodel = _userService.Get(id).ToDTO(); // After the object has been changed we have to define it (if we want) again and reGet it's values
                return CreatedAtAction(nameof(Get), new { toto = id }, changedmodel);
            }
            catch (SqlException)
            {
                return StatusCode(500);
            }
            catch(ArgumentOutOfRangeException)
            {
                return NotFound();
            }
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]


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


        [HttpPost("CheckPassword")]//api/user/CheckPassword is the route to access here and to avoid repeating the route for the simple Post function
        [ProducesResponseType(500)]
        [ProducesResponseType<UserDTO>(200)]
        [ProducesResponseType(401)]

        public IActionResult CheckPassword([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                Guid id = _userService.CheckPassword(email, password);
                UserDTO model = _userService.Get(id).ToDTO();
                return Ok(model);
            }
            catch(SqlException)
            {
                return StatusCode(500);
            }
            catch (Exception)
            {
                return Unauthorized(); //code 401
            }
        }


    }
}
