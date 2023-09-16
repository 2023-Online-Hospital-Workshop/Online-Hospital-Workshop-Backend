using System.Text.Json;
using hospital_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hospital_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ModelContext _context;

        public RegistrationController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetRegistrations()
        {
            var today = DateTime.Now.Date;
            var nextWeek = today.AddDays(7);

            var registrations = await _context.Registrations.Where(r => r.AppointmentTime.Date >= today && r.AppointmentTime.Date <= nextWeek).ToListAsync();

            var result = registrations.GroupBy(r => new { Date = r.AppointmentTime.Date, Period = r.Period })
                                      .Select(g => new { Date = g.Key.Date, Period = g.Key.Period, Count = g.Count() })
                                      .ToList();



            var json = JsonSerializer.Serialize(result);

            return Content(json, "application/json");
        }
    }

}
