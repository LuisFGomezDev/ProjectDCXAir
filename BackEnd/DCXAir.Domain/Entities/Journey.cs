using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCXAir.Domain.Entities
{
    public class Journey
    {
        public string Origin { get; set; }
        public string Destination{ get; set; }
        public double Price { get; set; }//acumulado de la lista de vuelos 
        public List<Flight> Flights { get; set; }
    }
}
