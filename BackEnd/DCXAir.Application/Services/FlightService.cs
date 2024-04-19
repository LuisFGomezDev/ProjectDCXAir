using DCXAir.Domain.DTO;
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


        public async Task<List<string>> GetDestinations()
        {
            return await _flightRepository.GetDestinations();
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

            var firstSegm = await _flightRepository.FindFlightsByOrigin(origin);
            var SecondSegm = await _flightRepository.FindFlightsByDestination(destination);

            foreach (var itemFS in firstSegm)
            {
                foreach (var itemSS in SecondSegm.Where(f => f.Origin == itemFS.Destination))
                {
                    journeys.Add(new Journey
                    {
                        Flights = new List<Flight> { itemFS, itemSS },
                        Origin = origin,
                        Destination = destination,
                        Price = itemFS.Price + itemSS.Price
                    });

                }

            }

            return journeys;
        }

        public async Task <RoundTripDTO> GetRoundTripFligthsAsync(string origin, string destination)
        {
            var OneWayFlights = await GetOneWayFligthsAsync(origin, destination);
            var BackWayFlights = await GetOneWayFligthsAsync(destination, origin);

            var roundTrip = new RoundTripDTO() { oneWayFlights = OneWayFlights, backWayFlights = BackWayFlights, Origin = origin, Destination = destination };

            return roundTrip;
        }
    }
}
