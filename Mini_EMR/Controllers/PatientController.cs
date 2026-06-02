using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_EMR.Entities;
using Mini_EMR.Models.Patients;
using Mini_EMR.Services.Interfaces;
using System.Security.Claims;

namespace Mini_EMR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var patients = await _service.GetAllPatientsAsync();
            return Ok(new
            {
                Message = "Patient Fetched successfully",
                patients
            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync( int id )
        {
            var patient = await _service.GetPatientByIdAsync(id);
            if(patient == null)
            {
                return NotFound(new {message = "Patient not found against this id"});
            }
            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePatientModel model)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var patient = await _service.CreatePatientAsync( model,userId);

            return Ok(new
            {
                Message = "Patient Added successfully", patient 
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(
            int id,
            UpdatePatientModel model)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var updated = await _service.UpdatePatientAsync(id,model,userId);

            if (!updated)
            {
                return NotFound(new
                {
                    Message = "Patient not found"
                });
            }

            return Ok(new
            {
                Message = "Patient updated successfully"
            });
        }
        [HttpGet("{id}/visits")]
        [Authorize(Roles = "Doctor,Receptionist")]
        public async Task<IActionResult> GetPatientVisitsAsync(int id)
        {
            var visits = await _service.GetVisitsByPatientIdAsync(id);
            return Ok(visits);
        }

    }
}
