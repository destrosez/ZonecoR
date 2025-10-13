using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ZonecoR.Contracts.Users;

namespace ZonecoR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) { _service = service; }

        [HttpGet]
        [SwaggerOperation(Summary = "Получение списка всех пользователей БД")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll();
            return Ok(data.Adapt<IEnumerable<UserResponse>>());
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Получение пользователя по идентификатору")]
        public async Task<IActionResult> Get(int id)
        {
            var m = await _service.GetById(id);
            if (m == null) { return NotFound(); }
            return Ok(m.Adapt<UserResponse>());
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Создание пользователя")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            var entity = request.Adapt<User>();
            entity.password_hash = request.Password;
            await _service.Create(entity);
            return Ok();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Обновление пользователя")]
        public async Task<IActionResult> Update([FromBody] UserResponse request)
        {
            var entity = request.Adapt<User>();
            await _service.Update(entity);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Удаление пользователя")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetById(id);
            if (existing == null) { return NotFound(); }
            await _service.Delete(id);
            return Ok();
        }
    }
}
