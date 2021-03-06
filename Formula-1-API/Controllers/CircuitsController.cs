﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Formula_1_API.Factories;
using Formula_1_API.Services.Interfaces;
using Formula_1_API.Repositories.Adapters;
using Formula_1_API.Utils;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Circuit>>> Get(int? page = 1, int? pageSize = 100)
        {
            return await this.baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Circuit>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Circuit>> Post([FromBody] Circuit value)
        {
            return await this.baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Circuit>> Put(int id, [FromBody] Circuit value)
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
