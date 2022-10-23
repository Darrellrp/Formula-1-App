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
    public class DriversController : ControllerBase
    {
        private readonly IService<Driver> _service;
        private readonly BaseController<Driver> _baseController;

        public DriversController(BaseController<Driver> baseController, IService<Driver> service)
        {
            this._baseController = baseController;
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> Get(int? page = 1, int pageSize = 100)
        {
            return await this._baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> Get(int id)
        {
            return await this._baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Driver>> Post([FromBody] Driver value)
        {
            return await this._baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Driver>> Put(int id, [FromBody] Driver value)
        {
            return await this._baseController.Put(id, value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await this._baseController.Delete(id);
        }
    }
}
