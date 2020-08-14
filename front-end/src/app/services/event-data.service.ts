import { Injectable, OnInit } from '@angular/core';
import {
  HttpClient,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { map, catchError, tap, shareReplay, switchMap } from 'rxjs/operators';
import { Event } from '../models/event.model';
import { Observable, throwError, BehaviorSubject, of } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EventDataService {

  private _reloadEvents$ = new BehaviorSubject<boolean>(true);
  constructor(private http: HttpClient) { }

  get events$(): Observable<Event[]> {
    return this.http.get(`${environment.apiUrl}/events/`).pipe(
      tap(console.log),
      shareReplay(1),
      catchError(this.handleError),
      map((list: any[]): Event[] => list.map(Event.fromJSON))
    );
  }

  getEvent$(id: string): Observable<Event> {
    return this.http
      .get(`${environment.apiUrl}/events/${id}`)
      .pipe(catchError(this.handleError), map(Event.fromJSON)); // returns just one event, as json
  }

  getEvents$(title?: string, startDate?: string, endDate?: string) {
    return this._reloadEvents$.pipe(
      switchMap(() => this.fetchEvents$(title, startDate, endDate))
    );
  }

  fetchEvents$(title?: string, startDate?: string, endDate?: string) {
    let params = new HttpParams();
    params = title ? params.append('title', title) : params;
    params = startDate ? params.append('startDate', startDate) : params;
    params = endDate ? params.append('endDate', endDate) : params;
    return this.http.get(`${environment.apiUrl}/events/`, { params }).pipe(
      catchError(this.handleError),
      map((list: any[]): Event[] => list.map(Event.fromJSON))
    );
  }

  addNewEvent(event: Event) {
    return this.http
      .post(`${environment.apiUrl}/events/`, event.toJSON())
      .pipe(catchError(this.handleError), map(Event.fromJSON))
      .pipe(
        // temporary fix, while we use the behaviorsubject as a cache stream
        catchError((err) => {
          return throwError(err);
        }),
        tap((rec: Event) => {
          this._reloadEvents$.next(true);
        })
      );
  }

  deleteEvent(event: Event) {
    return this.http
      .delete(`${environment.apiUrl}/events/${event.id}`)
      .pipe(tap(console.log), catchError(this.handleError))
      .subscribe(() => {
        this._reloadEvents$.next(true);
      });
  }

  handleError(err: any): Observable<never> {
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      errorMessage = `An error occurred: ${err.error.message}`;
    } else if (err instanceof HttpErrorResponse) {
      console.log(err);
      errorMessage = `'${err.status} ${err.statusText}' when accessing '${err.url}'`;
    } else {
      errorMessage = err;
    }
    return throwError(errorMessage);
  }
}
