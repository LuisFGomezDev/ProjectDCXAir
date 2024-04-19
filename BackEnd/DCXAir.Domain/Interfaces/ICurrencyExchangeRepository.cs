namespace DCXAir.Domain.Interfaces
{
    public interface ICurrencyExchangeRepository
    {
        Task<decimal> GetConversionRateAsync(string toCurrency);
    }
}