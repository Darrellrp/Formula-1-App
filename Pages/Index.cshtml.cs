using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Formula_1_App.Pages
{
    public class IndexModel : PageModel
    {
        public string ApiServerUrl { get; set; } = string.Empty;

        public void OnGet()
        {
            this.ApiServerUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        }
    }
}
