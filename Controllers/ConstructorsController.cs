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
    public class ConstructorsController : ControllerBase
    {
        private readonly IService<Constructor> service;
        private readonly BaseController<Constructor> baseController;

        public ConstructorsController(BaseController<Constructor> baseController, IService<Constructor> service)
        {            
            this.baseController = baseController;
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Constructor>>> Get(int? page = 1, int pageSize = 100)
        {            
            return await this.baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Constructor>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Constructor>> Post([FromBody] Constructor value)
        {
            return await this.baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Constructor>> Put(int id, [FromBody] Constructor value)
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
