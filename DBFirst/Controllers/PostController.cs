using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Models;

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _postData;

        public PostController(IPost postData)
        {
            _postData = postData;
        }
        [HttpGet]
        public async Task<ActionResult<List<PostItem>>> GetPost()
        {
            List<PostItem> res = await _postData.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<PostItem>());
            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostItem post)
        {

            bool res = await _postData.NewPost(post);
            if (!res)
                return BadRequest();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutPost(int id, [FromBody] PostItem post)
        {
            bool res = await _postData.Update(id, post);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            bool res = await _postData.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();

        }
    }
}
