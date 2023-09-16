using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospital_backend.Controllers
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
