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

        [HttpGet("Destinations")]
        public async Task<IActionResult> GetDestinations()
        {
            var response = await _flightService.GetDestinations();
            return Ok(response);
        }

        /// <summary>
        /// Return a list of flights
        /// </summary>
        /// <returns></returns>
        [HttpGet("OneWayFlights/{origin}/{destination}/{currency}")]
        public async Task<IActionResult> GetOneWayFligths(string origin, string destination, string currency)
        {
            var res = await _flightService.GetOneWayFligthsAsync(origin, destination, currency);
            return Ok(res);
        }

        [HttpGet("RoundTrip/{origin}/{destination}/{currency}")]
        public async Task<IActionResult> GetRoundTripFligths(string origin, string destination, string currency)
        {
            var res = await _flightService.GetRoundTripFligthsAsync(origin, destination, currency);
            return Ok(res);
        }


    }
}
