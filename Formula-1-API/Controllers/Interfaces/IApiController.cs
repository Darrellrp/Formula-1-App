using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Services;

namespace Formula_1_API.Controllers
{
    public interface IApiController<T> where T : class
    {
        [HttpGet]
        Task<ActionResult<IEnumerable<T>>> Get(int? page = null, int? pageSize = 100);

        [HttpGet("{id}")]
        Task<ActionResult<T>> Get(int id);

        [HttpPost]
        Task<ActionResult<T>> Post(T entity);

        [HttpPut("{id}")]
        Task<ActionResult<T>> Put(int id, T entity);

        [HttpDelete("{id}")]
        Task<IActionResult> Delete(int id);
    }
}
