using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Datasources;
using Formula_1_API.Factories;

namespace Formula_1_API.Controllers
{
    [Route("api")]
    public class MainController : Controller
    {
        private readonly MainEndpointFactory _mainEndpointFactory;
        public MainController(MainEndpointFactory mainEndpointFactory)
        {
            _mainEndpointFactory = mainEndpointFactory;
        }

        [HttpGet]
        public ActionResult<MainEndpoint> Get()
        {
            var mainEndpoint = _mainEndpointFactory.Create(this);

            return Ok(mainEndpoint);
        }
    }
}
