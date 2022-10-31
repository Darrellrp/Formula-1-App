using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_App.Models;
using Formula_1_App.Services;
using Formula_1_App.Datasources;
using Formula_1_App.Datasources.ClassMaps;
using Formula_1_App.Factories;

namespace Formula_1_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceResultsController : ControllerBase
    {
        private readonly IApiController<RaceResult> _baseController;

        public RaceResultsController(IApiController<RaceResult> baseController)
        {
            _baseController = baseController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceResult>>> Get(int? page = 1, int pageSize = 100)
        {
            return await _baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RaceResult>> Get(int id)
        {
            return await _baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<RaceResult>> Post([FromBody] RaceResult value)
        {
            return await _baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RaceResult>> Put(int id, [FromBody] RaceResult value)
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
