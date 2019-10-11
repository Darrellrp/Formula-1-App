using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Services;
using Formula_1_API.Models;
using Formula_1_API.Services.Interfaces;

namespace Formula_1_API.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase, IApiController<T> where T : class, IIdentifier
    {
        private readonly IService<T> _service;

        public BaseController(IService<T> service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get(int? page = null, int? pageSize = 100)
        {
            if(!page.HasValue)
            {
                var entities = await _service.GetAll();
                return Ok(entities);
            }

            var paginated_entities = await _service.GetPaginated((int) page, (int) pageSize);
            return Ok(paginated_entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _service.FindById(id);
            return Ok(entity);
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
