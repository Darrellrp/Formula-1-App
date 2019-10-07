using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using System.IO;
using Formula_1_API.Utils;
using Formula_1_API.Utils.ClassMaps;
using Formula_1_API.Factories;
using Formula_1_API.Services.Interfaces;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IService<Race> service;
        private readonly BaseController<Race> baseController;

        public RacesController(BaseController<Race> baseController, IService<Race> service)
        {
            this.baseController = baseController;
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> Get()
        {
            return await this.baseController.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Race>> Post([FromBody] Race value)
        {
            return await this.baseController.Post(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Race>> Put(int id, [FromBody] Race value)
        {
            return await this.baseController.Put(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await this.baseController.Delete(id);
        }
    }
}
