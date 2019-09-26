﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Formula_1_API.Models;
using Formula_1_API.Utils;
using Formula_1_API.Factories;

namespace Formula_1_API.Controllers
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
