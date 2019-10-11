using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Formula_1_API.Factories;
using Formula_1_API.Services.Interfaces;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstructorResultsController : ControllerBase
    {
        private readonly IService<ConstructorResult> service;
        private readonly BaseController<ConstructorResult> baseController;

        public ConstructorResultsController(BaseController<ConstructorResult> baseController, IService<ConstructorResult> service)
        {
            this.baseController = baseController;
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConstructorResult>>> Get(int? page = null, int? pageSize = 100)
        {
            if (!page.HasValue)
            {
                return await this.baseController.Get();
            }

            return await this.baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConstructorResult>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<ConstructorResult>> Post([FromBody] ConstructorResult value)
        {
            return await this.baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConstructorResult>> Put(int id, [FromBody] ConstructorResult value)
        {
            return await this.baseController.Put(id, value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await this.baseController.Delete(id);
        }
    }
}
