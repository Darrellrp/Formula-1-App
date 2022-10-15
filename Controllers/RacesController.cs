using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_App.Models;
using Formula_1_App.Services;
using System.IO;
using Formula_1_App.Utils;
using Formula_1_App.Utils.ClassMaps;
using Formula_1_App.Factories;
using Formula_1_App.Services.Interfaces;

namespace Formula_1_App.Controllers
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
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> Get(int? page = 1, int pageSize = 100)
        {
            return await this.baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Race>> Post([FromBody] Race value)
        {
            return await this.baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Race>> Put(int id, [FromBody] Race value)
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
