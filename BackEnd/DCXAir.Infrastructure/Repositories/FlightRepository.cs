using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DCXAir.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flights;

        public FlightRepository()
        {
            
            //initial flight information upload
            var jsonFilePath = "markets.json";
            var jsonData = File.ReadAllText(jsonFilePath);
            var flights = JsonSerializer.Deserialize<List<Flight>>(jsonData);

            _flights = flights;

        }

        public List<string> GetOrigins()
        {
            return _flights.Select(f => f.Origin).Distinct().ToList();
        }


        public async Task<List<Flight>> FindFlightsAsync(string origin, string destination)
        {
            return _flights.Where(f => f.Origin == origin && f.Destination == destination)
                               .ToList();

        }
        
        public async Task<List<Flight>> FindFlightsByOrigin(string origin)
        {
            return _flights.Where(f => f.Origin == origin)
                               .ToList();

        }
        
        public async Task<List<Flight>> FindFlightsByDestination(string destination)
        {
            return _flights.Where(f => f.Destination == destination)
                               .ToList();

        }
        public async Task<List<string>> GetDestinations()
        {
            return _flights.Select(f => f.Destination).Distinct().ToList();
        }

    }
}
