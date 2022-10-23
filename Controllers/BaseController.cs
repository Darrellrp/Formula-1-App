using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_App.Services;
using Formula_1_App.Models;
using Formula_1_App.Services.Interfaces;
using System.Linq;

namespace Formula_1_App.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase, IApiController<T> where T : class, IEntity
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get(int? page = null, int pageSize = 100)
        {
            IEnumerable<T> entities;

            if (!page.HasValue)
            {
                entities = await _service.GetAll();
            }
            else
            {
                entities = await _service.GetPaginated((int) page, pageSize);
            }

            return Ok(new Response<T>(entities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _service.FindById(id);

            if(entity == null)
            {
                return NotFound();
            }

            return Ok(new Response<T>(entity));
        }
        [HttpPost]
        public async Task<ActionResult<T>> Post(T entity)
        {
            var newEntity = await _service.Save(entity);
            return Ok(newEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(int id, T entity)
        {
            var updatedEntity = await _service.Update(entity);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.FindById(id);

            if (entity == null)
            {
                return NotFound();
            }

            await _service.Delete(entity);

            return NoContent();
        }
    }
}
