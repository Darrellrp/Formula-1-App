using Formula_1_App.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Formula_1_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        public ConfigurationController() { }

        [HttpGet]
        public ActionResult<ApiConfiguration> Get()
        {
            return Ok(new ApiConfiguration { ApiServerUrl = this.GetApiServerUrl() });
        }

        private string GetApiServerUrl()
        {
            return $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        }
    }
}
