using Microsoft.AspNetCore.Mvc;

namespace QuoteCalculatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "API IS RUNNING";
        }
    }
}