using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_EMR.Services.Interfaces;

namespace Mini_EMR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _service;

        public MedicinesController(
            IMedicineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>
            GetAllAsync()
        {
            var medicines =
                await _service.GetAllAsync();

            return Ok(medicines);
        }
    }
}