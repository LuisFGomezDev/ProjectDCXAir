using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;

namespace DCXAir.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }


        public List<string> GetOrigins()
        {
            return _flightRepository.GetOrigins();
        }


        public async Task<List<string>> GetDestinationsByOriginAsync(string origin)
        {
            return await _flightRepository.GetDestinationsByOriginAsync(origin);
        }


        public async Task<List<Journey>> GetOneWayFligthsAsync(string origin, string destination)
        {
            var flights = await _flightRepository.FindFlightsAsync(origin, destination);

            var journeys = new List<Journey>();
            foreach (var flight in flights)
            {
                var journey = new Journey
                {
                    Flights = new List<Flight> { flight },
                    Origin = origin,
                    Destination = destination,
                    Price = flight.Price
                };
                journeys.Add(journey);
            }

            return journeys;
        }
        public async Task<List<Journey>> GetRoundTripFligthsAsync(string origin, string destination)
        {
            var outboundFlights = await _flightRepository.FindFlightsAsync(origin, destination);


            var returnFlights = await _flightRepository.FindFlightsAsync(destination, origin);


            var journeys = new List<Journey>();

            foreach (var outbound in outboundFlights)
            {
                foreach (var returnFlight in returnFlights)
                {
                    var journey = new Journey
                    {
                        Flights = new List<Flight> { outbound, returnFlight },
                        Origin = origin,
                        Destination = destination,
                        Price = outbound.Price + returnFlight.Price
                    };
                    journeys.Add(journey);
                }
            }

            return journeys;
        }
    }
}
