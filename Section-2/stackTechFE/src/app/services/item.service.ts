import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Item } from '../models/item.model';

@Injectable({
  providedIn: 'root'
})
export class ItemService {
  private apiUrl = 'http://localhost:5000/api/items';

  constructor(private http: HttpClient) { }

  getItems(): Observable<Item[]> {
    return this.http.get<Item[]>(this.apiUrl).pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: any): Observable<never> {
    console.error('An error occurred:', error);
    return throwError(() => 'Something went wrong; please try again later.');
  }
}
