using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data.Entities;
using ToDoList.Data.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private readonly ITodoItemService _todoItemService;
        private readonly IUserService _userService;
        public TodoItemController(ITodoItemService todoItemService, IUserService userService)
        {
            _todoItemService = todoItemService;
            _userService = userService;
        }
        [HttpGet("id")]
        public IActionResult GetTodoItemById(int id)
        {
            Data.Entities.TodoItem todoItem = _todoItemService.GetTodoItemById(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        [HttpGet]
        public IActionResult GetAllTodoItems()
        {
            try
            {
                var todoItems = _todoItemService.GetAllTodoItems();

                if (todoItems == null || !todoItems.Any())
                {
                    return NotFound();
                }

                return Ok(todoItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostTodoItem(TodoItemPostDto todoItemPostDto)
        {
            //try
            //{
            //    var todoItem = new TodoItem
            //    {
            //        Title = todoItemPostDto.Title,
            //        Description = todoItemPostDto.Description
            //    };
            //    _todoItemService.PostTodoItem(todoItemPostDto);
            //    return CreatedAtAction(nameof(GetTodoItemById), new { id = todoItem.Id_Todo_Item }, todoItem);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Error: {ex.Message}");
            //}
            try
            {
                var newTodoItem = _todoItemService.PostTodoItem(todoItemPostDto);

                return CreatedAtAction(nameof(GetTodoItemById), new { id = newTodoItem.Id_Todo_Item }, newTodoItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }

}

