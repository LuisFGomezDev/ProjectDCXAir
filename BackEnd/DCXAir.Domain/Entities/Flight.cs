namespace DCXAir.Domain.Entities
{
    public class Flight
    {
        public Transport Transport { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }

        public Flight GetFlightWithNewPrice(decimal newPrice)
        {
            return new Flight()
            {
                Transport = Transport,
                Origin = Origin,
                Destination = Destination,
                Price = newPrice
            };
        }
    }
}
