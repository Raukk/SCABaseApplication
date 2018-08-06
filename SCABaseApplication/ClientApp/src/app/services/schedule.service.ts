import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ISchedule } from '../view_models/schedule.model';

@Injectable({
  providedIn: 'root',
})
export class ScheduleService {
  private url = '/api/Schedule/Schedules';
  constructor(private httpClient: HttpClient) { }

  getSchedules(facilityId: string, date: string): Observable<ISchedule[]> {
    let headers = new HttpHeaders();
    headers.append('Cache-Control', 'no-cache');
    headers.append('Pragma', 'no-cache');
    headers.append('Expires', 'Sat, 01 Jan 2000 00:00:00 GMT');

    return this.httpClient.get<ISchedule[]>(this.url + '/' + facilityId + '/' + date, {
      headers
    });
  }
}
