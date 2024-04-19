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
  
  public getDestination(originData: string) {
    const url = `${environment.api}/Flight/Destinations/${originData}`;
    return this.http.get(url);
  }


  
}
