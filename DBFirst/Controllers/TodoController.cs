using Microsoft.AspNetCore.Mvc;
using DAL.Interfaces;
using Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodo _todoData;

        public TodoController(ITodo todoData)
        {
            _todoData=todoData;
        }
        [HttpGet]
        public async Task <ActionResult<List<TodoItem>>>  GetTodo()
        {
           List<TodoItem> res=await _todoData.GetAll();
            if (res.Count == 0)
                return BadRequest(new List<TodoItem>());
           return Ok(res);

        }

        [HttpPost]
        public async Task<ActionResult> PostTodo([FromBody] TodoItem todo)
        {
            bool res=await _todoData.NewToDo(todo);
            if(!res)
                return BadRequest();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodo(int id, [FromBody] TodoItem todo)
        {
            bool res=await _todoData.Update(id,todo);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTodo(int id)
        {
            bool res= await _todoData.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();

        }
    }
}
