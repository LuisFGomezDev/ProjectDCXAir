using DCXAir.Domain.Entities;

namespace DCXAir.Domain.Interfaces
{
    public interface IFlightRepository
    {

        List<string> GetOrigins();
        Task<List<string>> GetDestinationsByOriginAsync(string origin);
        Task<List<Flight>> FindFlightsAsync(string origin, string destination);
    }
}
