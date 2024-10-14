// src/app/components/person/person.component.ts
import { Component, OnInit } from '@angular/core';
import { Person } from '../models/person.model';
import { PersonsService } from '../services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonsComponent implements OnInit {
  persons: Person[] = [];
  person: Person = { id: 0, name: '', nic: '' };
  isEdit = false;
  displayedColumns: string[] = ['id', 'name', 'nic', 'actions'];

  constructor(private personService: PersonsService) { }

  ngOnInit(): void {
    this.getAllPersons();
  }

  getAllPersons(): void {
    this.personService.getAllPersons().subscribe(
      (data) => this.persons = data,
      (error) => console.error('Error fetching persons', error)
    );
  }

  createPerson(): void {
    this.personService.createPerson(this.person).subscribe(
      () => {
        this.getAllPersons();
        this.resetForm();
      },
      (error) => console.error('Error creating person', error)
    );
  }

  updatePerson(): void {
    this.personService.updatePerson(this.person.id, this.person).subscribe(
      () => {
        this.getAllPersons();
        this.resetForm();
      },
      (error) => console.error('Error updating person', error)
    );
  }

  deletePerson(id: number): void {
    this.personService.deletePerson(id).subscribe(
      () => this.getAllPersons(),
      (error) => console.error('Error deleting person', error)
    );
  }

  editPerson(person: Person): void {
    this.person = { ...person };
    this.isEdit = true;
  }

  resetForm(): void {
    this.person = { id: 0, name: '', nic: '' };
    this.isEdit = false;
  }
}
