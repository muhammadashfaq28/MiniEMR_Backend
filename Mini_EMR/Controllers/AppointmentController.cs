using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_EMR.Models.Appointments;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(
            IAppointmentService service)
        {
            _service = service;
        }

        // GET BY DATE 

        [HttpGet]
        public async Task<IActionResult> GetAppointmentsByDateAsync(
                [FromQuery] DateTime date,
                [FromQuery] string? status)
        {
            var appointments =
                await _service
                    .GetAppointmentsByDateAsync(
                        date,
                        status);

            return Ok(appointments);
        }

        //  GET BY ID

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var appointment =
                await _service
                    .GetAppointmentByIdAsync(id);

            if (appointment == null)
            {
                return NotFound(new
                {
                    Message = "Appointment not found"
                });
            }

            return Ok(appointment);
        }

        //  DOCTOR TODAY 

        [HttpGet("doctor/today")]
        public async Task<IActionResult> GetDoctorTodayAppointmentsAsync()
        {
            var doctorId = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

            var appointments =
                await _service
                    .GetDoctorTodayAppointmentsAsync(
                        doctorId, DateTime.Today);

            return Ok(appointments);
        }

        // BOOK APPOINTMENT 

        [HttpPost]
        public async Task<IActionResult> BookAppointmentAsync(CreateAppointmentModel model)
        {
            var createdById = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

            var appointment =
                await _service
                    .BookAppointmentAsync(
                        model,
                        createdById);

            return Ok(new
            {
                Message = "Appointment Book successfully", appointment
            });
        }

        // CHECK IN 

        [HttpPut("{id}/checkin")]
        public async Task<IActionResult> CheckInAppointmentAsync(int id)
        {
            var updatedById = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

            var updated =
                await _service.CheckInAppointmentAsync(id,updatedById);

            if (!updated)
            {
                return NotFound(new
                {
                    Message = "Appointment not found"
                });
            }

            return Ok(new
            {
                Message = "Appointment checked in successfully"
            });
        }

        // CANCEL 

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelAppointmentAsync(int id)
        {
            var updatedById = int.Parse(
                User.FindFirstValue(
                    ClaimTypes.NameIdentifier)!);

            var updated =
                await _service
                    .CancelAppointmentAsync(
                        id,
                        updatedById);

            if (!updated)
            {
                return NotFound(new
                {
                    Message = "Appointment not found"
                });
            }

            return Ok(new
            {
                Message = "Appointment cancelled successfully"
            });
        }

        //  STATUS COUNTS 

        [HttpGet("status-counts")]
        public async Task<IActionResult>GetStatusCountsByDateAsync([FromQuery] DateTime date)
        {
            var counts =
                await _service
                    .GetStatusCountsByDateAsync(date);

            return Ok(counts);
        }
    }
}