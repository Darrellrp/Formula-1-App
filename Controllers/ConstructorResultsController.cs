using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_App.Models;
using Formula_1_App.Services;
using Formula_1_App.Factories;

namespace Formula_1_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructorResultsController : ControllerBase
    {
        private readonly IApiController<ConstructorResult> _baseController;

        public ConstructorResultsController(IApiController<ConstructorResult> baseController)
        {
            _baseController = baseController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructorResult>>> Get(int? page = 1, int pageSize = 100)
        {            
            return await _baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructorResult>> Get(int id)
        {
            return await _baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ConstructorResult>> Post([FromBody] ConstructorResult value)
        {
            return await _baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConstructorResult>> Put(int id, [FromBody] ConstructorResult value)
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
