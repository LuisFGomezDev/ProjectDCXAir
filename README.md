TestFullstack

English:

Project for the systematization of flights for an airline developed with the following technical specifications: Backend: Technology .NET 7 – C# - API with 4 Endpoints Frontend: Technology Angular 15.2.9 – Angular Material 15.2.9 Node: V18.20.2 – Node Package Manager: npm 10.5.0

General instructions:

The Frontend displays a form which asks the user to choose an origin city, destination city, type of flight (OneWay - RoundTrip) and choose a currency to calculate the total cost of the entire flight path including possible stopovers in both modalities. The Backend exposes 4 endpoints which can be tested with SWAGGER:

DCXAir.API

GET/api/Flight/Origins

GET/api/Flight/Destinations

GET/api/Flight/OneWayFlights/{origin}/{destination}/{currency}

GET/api/Flight/RoundTrip/{origin}/{destination}/{currency}

Spanish:

Proyecto para la sistematización de vuelos de una aerolínea desarrollado con las siguientes especificaciones técnicas: Backend: Tecnología .NET 7 – C# - API con 4 Endpoints Frontend: Tecnología Angular 15.2.9 – Angular Material 15.2.9 – Node: V18.20.2 – Node Package Manager: npm 10.5.0

Instrucciones Generales:

El Frontend expone un formulario el cual le solicita al usuario elegir una ciudad origen, ciudad destino, tipo de vuelo (OneWay - RoundTrip) y elegir una currency para calcular el costo total de todo el trayecto de vuelo incluyendo las posibles escalas en ambas modalidades. El Backend expone 4 endpoints los cuales pueden ser probados con SWAGGER:

DCXAir.API

GET/api/Flight/Origins

GET/api/Flight/Destinations

GET/api/Flight/OneWayFlights/{origin}/{destination}/{currency}

GET/api/Flight/RoundTrip/{origin}/{destination}/{currency}
