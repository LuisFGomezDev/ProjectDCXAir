using DCXAir.Application.Interfaces;
using DCXAir.Domain.DTO;
using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;

namespace DCXAir.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ICurrencyExchangeService _currencyExchangeService;

        public FlightService(IFlightRepository flightRepository, ICurrencyExchangeService currencyExchangeService)
        {
            _flightRepository = flightRepository;
            _currencyExchangeService = currencyExchangeService;
        }


        public List<string> GetOrigins()
        {
            return _flightRepository.GetOrigins();
        }


        public async Task<List<string>> GetDestinations()
        {
            return await _flightRepository.GetDestinations();
        }


        public async Task<List<Journey>> GetOneWayFligthsAsync(string origin, string destination, string currency)
        {
            var flights = await _flightRepository.FindFlightsAsync(origin, destination);
            var journeys = new List<Journey>();

            foreach (var flight in flights)
            {
                var newPrice = await _currencyExchangeService.CurrencyConvert(currency, flight.Price);
                var journey = new Journey
                {
                    Flights = new List<Flight> { flight.GetFlightWithNewPrice(newPrice) },
                    Origin = origin,
                    Destination = destination,
                    Price = newPrice,
                    CurrencyName = currency
                };
                journeys.Add(journey);
            }

            var firstSegm = await _flightRepository.FindFlightsByOrigin(origin);
            var SecondSegm = await _flightRepository.FindFlightsByDestination(destination);

            foreach (var itemFS in firstSegm)
            {
                foreach (var itemSS in SecondSegm.Where(f => f.Origin == itemFS.Destination))
                {
                    var newPriceItemFS = await _currencyExchangeService.CurrencyConvert(currency, itemFS.Price);
                    var newPriceItemSS = await _currencyExchangeService.CurrencyConvert(currency, itemSS.Price);
                    journeys.Add(new Journey
                    {
                        Flights = new List<Flight> { itemFS.GetFlightWithNewPrice(newPriceItemFS), itemSS.GetFlightWithNewPrice(newPriceItemSS) },
                        Origin = origin,
                        Destination = destination,
                        Price = newPriceItemFS + newPriceItemSS,
                        CurrencyName = currency
                    });
                }
            }

            return journeys;
        }

        public async Task<RoundTripDTO> GetRoundTripFligthsAsync(string origin, string destination, string currency)
        {
            var OneWayFlights = await GetOneWayFligthsAsync(origin, destination, currency);
            var BackWayFlights = await GetOneWayFligthsAsync(destination, origin, currency);

            var roundTrip = new RoundTripDTO() { oneWayFlights = OneWayFlights, backWayFlights = BackWayFlights, Origin = origin, Destination = destination };

            return roundTrip;
        }
    }
}
