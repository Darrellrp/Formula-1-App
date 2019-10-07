using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Formula_1_API.Factories;
using Formula_1_API.Services.Interfaces;
using Formula_1_API.Repositories.Adapters;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitsController : ControllerBase
    {
        private readonly IService<Circuit> service;
        private readonly BaseController<Circuit> baseController;

        public CircuitsController(BaseController<Circuit> baseController, IService<Circuit> service)
        {
            this.baseController = baseController;
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circuit>>> Get()
        {
            var adapter = new MongoAdapter<Circuit>();

            //await adapter.Add(new Circuit()  {
            //    Id = 2,
            //    Ref = "albert_park",
            //    Name = "Albert Park Grand Prix Circuit",
            //    Location = "Melbourne",
            //    Country = "Australia",
            //    Lat = "-37.8497",
            //    Lng = "144.968",
            //    Url = "http://en.wikipedia.org/wiki/Melbourne_Grand_Prix_Circuit"
            //});
            //var t = await adapter.FindById(1);
            //var t = await adapter.GetAll();
            //var t = await adapter.Delete(new Circuit()  {
            //    Id = 2,
            //    Ref = "albert_park",
            //    Name = "Albert Park Grand Prix Circuit",
            //    Location = "Melbourne",
            //    Country = "Australia",
            //    Lat = "-37.8497",
            //    Lng = "144.968",
            //    Url = "http://en.wikipedia.org/wiki/Melbourne_Grand_Prix_Circuit"
            //});

            return await this.baseController.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Circuit>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Circuit>> Post([FromBody] Circuit value)
        {
            return await this.baseController.Post(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Circuit>> Put(int id, [FromBody] Circuit value)
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
