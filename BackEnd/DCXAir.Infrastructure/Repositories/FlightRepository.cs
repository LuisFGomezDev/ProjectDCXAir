using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DCXAir.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly List<Flight> _flights;

        public FlightRepository(List<Flight> flights)
        {
            _flights = flights;
        }

        public List<string> GetOrigins()
        {
            return _flights.Select(f => f.Origin).Distinct().ToList();
        }
        public async Task<List<string>> GetDestinationsByOriginAsync(string origin)
        {
            return _flights.Where(f => f.Origin == origin).Select(f => f.Destination).Distinct().ToList();
        }
        public async Task<List<Flight>> FindFlightsAsync(string origin, string destination)
        {
            return _flights.Where(f => f.Origin == origin && f.Destination == destination)
                               .ToList();
        }
    }
}
