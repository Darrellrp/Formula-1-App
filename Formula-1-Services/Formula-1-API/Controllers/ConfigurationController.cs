using Formula_1_API.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Formula_1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        public ConfigurationController() { }

        [HttpGet]
        public ActionResult<ApiConfiguration> Get()
        {
            return Ok(new ApiConfiguration { ApiServerUrl = GetApiServerUrl() });
        }

        private string GetApiServerUrl()
        {
            return $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
        }
    }
}
