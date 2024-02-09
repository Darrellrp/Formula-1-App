using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Formula_1_API.Factories;
using Formula_1_API.Datasources;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitsController : ControllerBase
    {
        private readonly IApiController<Circuit> _baseController;

        public CircuitsController(IApiController<Circuit> baseController)
        {
            _baseController = baseController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circuit>>> Get(int page = 0, int pageSize = 100)
        {
            return await _baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Circuit>> Get(int id)
        {
            return await _baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Circuit>> Post([FromBody] Circuit value)
        {
            return await _baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Circuit>> Put(int id, [FromBody] Circuit value)
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
