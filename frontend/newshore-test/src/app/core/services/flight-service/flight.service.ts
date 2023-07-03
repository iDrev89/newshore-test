import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FlightService {
  constructor(private _http: HttpClient) {}

  private flightsData$Subject: Subject<any> = new Subject<any>();
  public flightsData$ = this.flightsData$Subject.asObservable();

  searchFlights({ origin, destination }: { origin: string; destination: string }) {
    const params = new HttpParams().set('Origin', origin).set('Destination', destination);
    this._http.get<FlightResponse>('/Flight', { params }).subscribe((response) => this.flightsData(response.data));
  }
  flightsData(data: Journey[]) {
    console.log('data', data);
    this.flightsData$Subject.next(data);
  }
}
