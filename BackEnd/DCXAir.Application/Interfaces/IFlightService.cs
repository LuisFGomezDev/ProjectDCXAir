using DCXAir.Domain.DTO;
using DCXAir.Domain.Entities;

namespace DCXAir.Domain.Interfaces
{
    public interface IFlightService
    {
        List<string> GetOrigins();
        Task<List<string>> GetDestinations();
        Task<List<Journey>> GetOneWayFligthsAsync(string origin, string destination);
        Task<RoundTripDTO> GetRoundTripFligthsAsync(string origin, string destination);
    }
}
