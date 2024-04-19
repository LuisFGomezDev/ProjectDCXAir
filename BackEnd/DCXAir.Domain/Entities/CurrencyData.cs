using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DCXAir.Domain.Entities
{
    public class CurrencyData
    {
        public string date { get; set; }
        [JsonPropertyName("usd")]
        public Dictionary<string, decimal> Rates { get; set; }
    }

}
