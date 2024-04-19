namespace DCXAir.Application.Interfaces
{
    public interface ICurrencyExchangeService
    {
        Task<decimal> CurrencyConvert(string toCurrency, decimal usdValue);
    }
}