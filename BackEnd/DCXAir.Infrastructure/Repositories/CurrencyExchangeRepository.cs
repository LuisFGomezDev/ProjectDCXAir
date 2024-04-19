using DCXAir.Domain.Entities;
using DCXAir.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DCXAir.Infrastructure.Repositories
{
    public class CurrencyExchangeRepository : ICurrencyExchangeRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        public CurrencyExchangeRepository(IMemoryCache memoryCache)
        {
            _httpClient = new HttpClient();
            _memoryCache = memoryCache;
        }

        public async Task<decimal> GetConversionRateAsync(string toCurrency)
        {
            string cacheKey = $"usd-to-{toCurrency}-{DateTime.UtcNow.Date}";

            // Intentar obtener el valor de la caché
            if (_memoryCache.TryGetValue(cacheKey, out decimal rate))
            {
                return rate;
            }

            string url = $"https://cdn.jsdelivr.net/npm/@fawazahmed0/currency-api@2024-04-17/v1/currencies/usd.json";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var currencyData = JsonSerializer.Deserialize<CurrencyData>(json, options);

                if (currencyData != null && currencyData.Currencies.ContainsKey(toCurrency.ToLower()))
                {
                    rate = currencyData.Currencies[toCurrency.ToLower()];
                    // Guardar en caché la tasa de cambio con un tiempo de expiración de 24 horas
                    _memoryCache.Set(cacheKey, rate, TimeSpan.FromDays(1));
                    return rate;
                }
                throw new Exception("Currency not found.");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return 0;
            }
        }
    }
}
