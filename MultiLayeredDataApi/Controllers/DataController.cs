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
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _dataService.GetDataAsync(id);
            return data != null ? Ok(data) : NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] DataItemDto dto)
        {
            await _dataService.AddDataAsync(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] DataItemDto dto)
        {
            await _dataService.UpdateDataAsync( dto);
            return Ok();
        }
    }

}
