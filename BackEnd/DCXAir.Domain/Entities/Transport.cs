using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCXAir.Domain.Entities
{
    public class Transport
    {
        public int TransportId { get; set; } 
        public string FlightCarrier { get; set; } 
        public string FlightNumber { get; set; } 
    }
}
