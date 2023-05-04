using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Services;
using Formula_1_API.Models;
using System.Linq;

namespace Formula_1_API.Controllers
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
        public async Task<ActionResult<IEnumerable<T>>> Get(int page = 0, int pageSize = 100)
        {
            DbResult<T> result;

            if (page < 1)
            {
                result = await _service.GetAll();
            }
            else
            {
                result = await _service.GetPaginated(page, pageSize);
            }

            return Ok(new Response<T>(result.CollectionLabel, result.Collection));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var result = await _service.FindById(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(new Response<T>(result.CollectionLabel, result.Collection));
        }
        [HttpPost]
        public async Task<ActionResult<T>> Post(T result)
        {
            var newEntity = await _service.Save(result);
            return Ok(newEntity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<T>> Put(int id, T result)
        {
            var updatedEntity = await _service.Update(id, result);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.FindById(id);

            if (result == null)
            {
                return NotFound();
            }

            await _service.Delete(result.Record);
            return NoContent();
        }
    }
}
