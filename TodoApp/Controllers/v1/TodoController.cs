using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoApp.Contracts.V1;
using TodoApp.Contracts.V1.Requests;
using TodoApp.Contracts.V1.Responses;
using TodoApp.Domain;
using TodoApp.Service;

namespace TodoApp.Controllers.v1
{
    public class TodoController : Controller
    {
        private ITodoService _todoService;
        private IMapper _mapper;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpPost(AppRoutes.Item.Create)]
        public async Task<IActionResult> Create([FromBody] TodoItemRequest todoItemRequest)
        {
            var item = new TodoItem
            {
                Id = new Guid(),
                CreateDate = DateTime.Now,
                Name = todoItemRequest.Name,
                Completed = false
            };

            item = await _todoService.CreateAsync(item);

            if (item == null)
            {
                return BadRequest(new { error = "Invalid entry" });
            }

            return Ok(item);
        }

        [HttpGet(AppRoutes.Item.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _todoService.GetAllAsync());
        }

        [HttpGet(AppRoutes.Item.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var item = await _todoService.GetAsync(id);

            if(item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpDelete(AppRoutes.Item.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleted = await _todoService.DeleteAsync(id);

            if(deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut(AppRoutes.Item.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]TodoItemRequest todoItemRequest)
        {
            var item = await _todoService.GetAsync(id);

            if (item == null)
            {
                return BadRequest(new { error = "Invalid todo Id provided" });
            }

            item.Name = todoItemRequest.Name;

            var update = await _todoService.UpdateAsync(item);

            if(update)
                return Ok(item);

            return NotFound();
        }
    }
}
