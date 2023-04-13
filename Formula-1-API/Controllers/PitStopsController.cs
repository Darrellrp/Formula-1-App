﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Services;
using Formula_1_API.Datasources;
using Formula_1_API.Datasources.ClassMaps;
using Formula_1_API.Factories;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PitStopsController : ControllerBase
    {
        private readonly IApiController<PitStop> _baseController;

        public PitStopsController(IApiController<PitStop> baseController)
        {
            _baseController = baseController;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PitStop>>> Get(int page = 0, int pageSize = 100)
        {
            return await _baseController.Get(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PitStop>> Get(int id)
        {
            return await _baseController.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<PitStop>> Post([FromBody] PitStop value)
        {
            return await _baseController.Post(value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PitStop>> Put(int id, [FromBody] PitStop value)
        {
            return await _baseController.Put(id, value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _baseController.Delete(id);
        }
    }
}