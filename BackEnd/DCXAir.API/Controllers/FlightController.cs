using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;
using DCXAir.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DCXAir.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("Origins")]
        public async Task<IActionResult> GetOrigins()
        {
            var response = _flightService.GetOrigins();
            return Ok(response);
        }
        [HttpGet("Destinations/{origin}")]
        public async Task<IActionResult> GetDestinationsByOrigin(string origin)
        {
            var response = await _flightService.GetDestinationsByOriginAsync(origin);
            return Ok(response);
        }
        /// <summary>
        /// Return a list of flights
        /// </summary>
        /// <returns></returns>
        [HttpGet("OneWayFlights/{origin}/{destination}/{currency}")]
        public async Task<IActionResult> GetOneWayFligths(string origin, string destination, string currency)
        {
            var res = await _flightService.GetOneWayFligthsAsync(origin, destination);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoundTripFligths(string origin, string destination, string currency)
        {
            var res = _flightService.GetRoundTripFligthsAsync(origin, destination);
            return Ok(res);
        }


    }
}
