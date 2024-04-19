using DCXAir.Domain.Entities;

namespace DCXAir.Domain.Interfaces
{
    public interface IFlightRepository
    {

        List<string> GetOrigins();

        Task<List<Flight>> FindFlightsAsync(string origin, string destination);

        Task<List<Flight>> FindFlightsByOrigin(string origin);

        Task<List<Flight>> FindFlightsByDestination(string destination);

        Task<List<string>> GetDestinations();

    }
}
