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
    public class ResultStatusController : ControllerBase
    {
        private readonly IService<ResultStatus> service;
        private readonly BaseController<ResultStatus> baseController;

        public ResultStatusController(BaseController<ResultStatus> baseController, IService<ResultStatus> service)
        {
            this.baseController = baseController;
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultStatus>>> Get()
        {
            return await this.baseController.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultStatus>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ResultStatus>> Post([FromBody] ResultStatus value)
        {
            return await this.baseController.Post(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ResultStatus>> Put(int id, [FromBody] ResultStatus value)
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
