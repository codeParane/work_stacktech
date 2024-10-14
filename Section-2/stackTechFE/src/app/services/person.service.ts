import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/person.model';

@Injectable({
  providedIn: 'root'
})
export class PersonsService {
  private apiUrl = 'http://localhost:5169/api/persons';

  constructor(private http: HttpClient) { }

  getAllPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.apiUrl);
  }

  getPersonById(id: number): Observable<Person> {
    return this.http.get<Person>(`${this.apiUrl}/${id}`);
  }

  createPerson(person: Person): Observable<Person> {
    return this.http.post<Person>(this.apiUrl, person);
  }

  updatePerson(id: number, person: Person): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, person);
  }

  deletePerson(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
