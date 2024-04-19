using DCXAir.Application.Interfaces;
using DCXAir.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCXAir.Application.Services
{
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;

        public CurrencyExchangeService(ICurrencyExchangeRepository currencyExchangeRepository)
        {
            _currencyExchangeRepository = currencyExchangeRepository;
        }

        public async Task<decimal> CurrencyConvert(string toCurrency, decimal usdValue)
        {
            var rate = await _currencyExchangeRepository.GetConversionRateAsync(toCurrency);
            return usdValue * rate;

        }
    }
}
