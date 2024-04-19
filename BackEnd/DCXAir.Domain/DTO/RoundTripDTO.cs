using DCXAir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCXAir.Domain.DTO
{
    public class RoundTripDTO
    {   
        public List<Journey> oneWayFlights { get; set; }
        public List<Journey> backWayFlights { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }

    }
}
