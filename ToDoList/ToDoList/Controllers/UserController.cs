using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data.Entities;
using ToDoList.Data.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("idAlt")]
        public IActionResult GetUserByIdAlt(int id, bool includeTodos = false)
        {
            try
            {
                var user = _userService.GetUserByIdAlt(id, includeTodos);
                if (user == null)
                {
                    return NotFound();
                }
                //mapea la entidad User con UserIncludeTodosDto
                if (includeTodos)
                {
                    var userIncludeTodosDto = new UserDto
                    {
                        Id_User = user.Id_User,
                        Name = user.Name,
                        Email = user.Email,
                        Address = user.Address,
                        TodoItems = user.TodoItems.Select(todo => new TodoItemDto
                        {
                            Id_Todo_Item = todo.Id_Todo_Item,
                            Title = todo.Title,
                            Description = todo.Description
                        }).ToList()
                    };
                    return Ok(userIncludeTodosDto);
                }
                //mapea la entidad User con UserDto
                else
                {
                    var userDto = new UserDto
                    {
                        Id_User = user.Id_User,
                        Name = user.Name,
                        Email = user.Email,
                        Address = user.Address
                    };
                    return Ok(userDto);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAllUsers(bool includeTodos = false)
        {
            try
            {
                var users = _userService.GetAllUsers(includeTodos);

                if (users == null)
                {
                    return NotFound();
                }

                // Mapear la lista de usuarios a DTOs según corresponda
                if (includeTodos)
                {
                    var usersIncludeTodosDto = users.Select(user => new UserDto
                    {
                        Id_User = user.Id_User,
                        Name = user.Name,
                        Email = user.Email,
                        Address = user.Address,
                        TodoItems = user.TodoItems.Select(todo => new TodoItemDto
                        {
                            Id_Todo_Item = todo.Id_Todo_Item,
                            Title = todo.Title,
                            Description = todo.Description
                        }).ToList()
                    }).ToList();

                    return Ok(usersIncludeTodosDto);
                }
                else
                {
                    var usersDto = users.Select(user => new UserDto
                    {
                        Id_User = user.Id_User,
                        Name = user.Name,
                        Email = user.Email,
                        Address = user.Address
                    }).ToList();

                    return Ok(usersDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult PostUser(UserPostDto userPostDto)
        {
            try
            {
                var user = new User
                {
                    Name = userPostDto.Name,
                    Email = userPostDto.Email,
                    Address = userPostDto.Address
                };
                _userService.PostUser(userPostDto);
                var userDto = new UserDto
                {
                    Id_User = user.Id_User,
                    Name = user.Name,
                    Email = user.Email,
                    Address = user.Address
                };
                return CreatedAtAction(nameof(GetUserByIdAlt), new { idAlt = user.Id_User }, userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
