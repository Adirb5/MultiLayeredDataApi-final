using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Services.Interfaces;

namespace MultiLayeredDataApi.Controllers
{
    [ApiController]
    [Route("data")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _service;

        public DataController(IDataService service) => _service = service;

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetData(id);
            return data != null ? Ok(data) : NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] DataItemDto dto)
        {
            await _service.AddData(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] DataItemDto dto)
        {
            await _service.UpdateData(id, dto);
            return Ok();
        }
    }

}
