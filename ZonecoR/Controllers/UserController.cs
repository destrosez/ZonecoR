using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models = DataAccess.Data;

namespace ZonecoR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.user model)
        {
            await _service.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Models.user model)
        {
            await _service.Update(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}