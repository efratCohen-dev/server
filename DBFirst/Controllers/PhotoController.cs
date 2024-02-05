using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Models;

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private readonly IPhoto _photoData;
        public PhotoController(IPhoto photoData)
        {
            _photoData = photoData;
        }
        [HttpGet]
        public async Task<ActionResult<List<PhotoItem>>> GetPhoto()
        {
            List<PhotoItem> res = await _photoData.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<PhotoItem>());
            return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult> PostPhoto([FromBody] PhotoItem photo)
        {
            bool res = await _photoData.NewPhoto(photo);
            if (!res)
                return BadRequest();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutPhoto(int id, [FromBody] PhotoItem photo)
        {
            bool res = await _photoData.Update(id, photo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            bool res = await _photoData.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();

        }
    }
}
