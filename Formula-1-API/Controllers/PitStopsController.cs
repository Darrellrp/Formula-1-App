﻿using System;
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
    public class PitStopsController : ControllerBase
    {
        private readonly IService<PitStop> service;
        private readonly BaseController<PitStop> baseController;

        public PitStopsController(BaseController<PitStop> baseController, IService<PitStop> service)
        {
            this.baseController = baseController;
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PitStop>>> Get(int? page = 1, int? pageSize = 100)
        {
            return await this.baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PitStop>> Get(int id)
        {
            return await this.baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<PitStop>> Post([FromBody] PitStop value)
        {
            return await this.baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PitStop>> Put(int id, [FromBody] PitStop value)
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
