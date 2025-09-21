using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var m = await _service.GetById(id);
            if (m == null)
            {
                return NotFound();
            }

            return Ok(m);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] user m)
        {
            await _service.Create(m);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] user m)
        {
            await _service.Update(m);
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