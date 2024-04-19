import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FlightService {
  constructor(private http: HttpClient) {}

  public getOrigins() {
    const url = `${environment.api}/Flight/Origins`;
    return this.http.get(url);
  }

  public getDestination() {
    const url = `${environment.api}/Flight/Destinations`;
    return this.http.get(url);
  }
  public getOneWayFligth(origin, destination, currency) {
    const url = `${environment.api}/Flight/OneWayFlights/${origin}/${destination}/${currency}`;
    return this.http.get(url);
  }
  public getRoundTripFligth(origin, destination, currency) {
    const url = `${environment.api}/Flight/RoundTrip/${origin}/${destination}/${currency}`;
    return this.http.get(url);
  }

  
}
