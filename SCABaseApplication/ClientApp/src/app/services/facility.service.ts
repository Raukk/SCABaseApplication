import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IFacility } from '../view_models/facility.model';

@Injectable({
  providedIn: 'root',
})
export class FacilityService {
  private url = '/api/Facility/Facilities';
  constructor(private httpClient: HttpClient) { }

  getFacilities(): Observable<IFacility[]> {
    let headers = new HttpHeaders();
    headers.append('Cache-Control', 'no-cache');
    headers.append('Pragma', 'no-cache');
    headers.append('Expires', 'Sat, 01 Jan 2000 00:00:00 GMT');

    return this.httpClient.get<IFacility[]>(this.url, {
      headers
    });
  }
}
