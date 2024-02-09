using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Formula_1_API.Datasources;
using Formula_1_API.Datasources.ClassMaps;
using Formula_1_API.Factories;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverStandingsController : ControllerBase
    {
        private readonly IApiController<DriverStanding> _baseController;

        public DriverStandingsController(IApiController<DriverStanding> baseController)
        {
            _baseController = baseController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverStanding>>> Get(int page = 0, int pageSize = 100)
        {
            return await _baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DriverStanding>> Get(int id)
        {
            return await _baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<DriverStanding>> Post([FromBody] DriverStanding value)
        {
            return await _baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DriverStanding>> Put(int id, [FromBody] DriverStanding value)
        {
            return await _baseController.Put(id, value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _baseController.Delete(id);
        }
    }
}
