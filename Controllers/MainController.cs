using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_App.Models;
using Formula_1_App.Utils;
using Formula_1_App.Factories;

namespace Formula_1_App.Controllers
{
    [Route("api")]
    public class MainController : Controller
    {
        
        [HttpGet]
        public ActionResult<MainEndpoint> Get()
        {
            var mainEndpoint = MainEndpointFactory.Create(this);

            return Ok(mainEndpoint);
        }        
    }
}
