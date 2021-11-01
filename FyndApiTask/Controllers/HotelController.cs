using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using FyndApiTask.Model;
using FyndApiTask.Service;

namespace FyndApiTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IHotelService _service;

        public HotelController(ILogger<HotelController> logger, IHotelService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get(int hotelId, DateTime arrivalDate)
        {
            try
            {
                List<Root> data = _service.GetByHotelIdAndArrivedDate(hotelId, arrivalDate);

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return StatusCode(400, "There was an error on getting data");
            }
        }
    }
}
