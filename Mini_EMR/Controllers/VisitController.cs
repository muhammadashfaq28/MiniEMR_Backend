using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_EMR.Models.Visits;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Doctor")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _service;

        public VisitsController(IVisitService service)
        {
            _service = service;
        }

        [HttpGet("{appointmentId}")]
        public async Task<IActionResult> GetByAppointmentIdAsync(int appointmentId)
        {
            var visit = await _service.GetByAppointmentIdAsync(appointmentId);

            if (visit == null)
            {
                return NotFound(new
                {
                    Message = "Visit not found"
                });
            }

            return Ok(visit);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitAsync(CreateVisitRequestModel model)
        {
            var visit =await _service.CreateVisitAsync(model);

            return Ok(visit);
        }
    }
}