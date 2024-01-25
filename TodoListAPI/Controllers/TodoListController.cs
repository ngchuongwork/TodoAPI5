using Microsoft.AspNetCore.Mvc;
using TodoListAPI.Models;
using TodoListAPI.Implements;
namespace TodoListAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        ITodoListService _service;
        public TodoListController(ITodoListService service)
        {
            this._service = service;
        }
        // GET: api/<TodoListController>
        [HttpGet]
        public IEnumerable<TodoList> Get()
        {
            return _service.GetAll();
        }

        // GET api/<TodoListController>/5
        [HttpGet("{id}")]
        public TodoList Get(int id)
        {
            return _service.Get(id);
        }

        // POST api/<TodoListController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormTodoListView _TodoList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TodoList todo = _service.Post(_TodoList);
            if (todo != null)
                return Ok(todo); 
            else
            {
                return Ok(0);
            }
        }

        // PUT api/<TodoListController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FormTodoListView updatedTodoList)
        {
            if (_service.Put(id, updatedTodoList) == 1)
                return Ok(1);
            else
            {
                // Log the exception
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if(_service.Delete(id)==1)  
                return NoContent(); // Xóa thành công, không có nội dung được trả về
            else{
                // Xử lý lỗi nếu có
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
