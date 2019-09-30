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

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LapTimesController : ControllerBase
    {
        private readonly IService<LapTime> service;
        private readonly BaseController<LapTime> baseController;

        public LapTimesController(BaseControllerFactory controllerFactory, IService<LapTime> _service)
        {
            this.service = _service;
            this.baseController = controllerFactory.Create(_service);
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LapTime>>> Get()
        {
            return await this.baseController.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LapTime>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<LapTime>> Post([FromBody] LapTime value)
        {
            return await this.baseController.Post(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LapTime>> Put(int id, [FromBody] LapTime value)
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
