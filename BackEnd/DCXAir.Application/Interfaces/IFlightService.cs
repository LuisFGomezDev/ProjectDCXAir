using DCXAir.Domain.Entities;

namespace DCXAir.Domain.Interfaces
{
    public interface IFlightService
    {
        List<string> GetOrigins();
        Task<List<string>> GetDestinationsByOriginAsync(string origin);
        Task<List<Journey>> GetOneWayFligthsAsync(string origin, string destination);
        Task<List<Journey>> GetRoundTripFligthsAsync(string origin, string destination);
    }
}
