using DCXAir.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCXAir.Application.Services
{
    public class CurrencyExchangeService
    {
        private readonly ICurrencyExchangeRepository _currencyExchangeRepository;   

        public CurrencyExchangeService() { }

        public object CurrencyConvert(string toCurrency, decimal usdValue) {
            _currencyExchangeRepository.GetConversionRateAsync(toCurrency);

            return null;

            
        } 
    }
}
