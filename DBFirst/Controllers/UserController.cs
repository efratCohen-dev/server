using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Models;

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _userData;
        public UserController(IUsers userData)
        {
            _userData = userData;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser()
        {
            List<User> res = await _userData.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<User>());
            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] User user)
        {
            bool res = await _userData.NewUser(user);
            if (!res)
                return BadRequest();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, [FromBody] User user)
        {
            bool res = await _userData.Update(id, user);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            bool res = await _userData.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();

        }
    }
}
