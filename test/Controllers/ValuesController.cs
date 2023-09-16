using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ContentResult Get(string pppp) {
            ContentResult result = new ContentResult();
            result.StatusCode = 200;
            result.Content = pppp+"hello!!!!!";
            return result;
        }
    }
}
