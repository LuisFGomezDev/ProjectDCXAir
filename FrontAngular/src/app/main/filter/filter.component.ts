import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {MatRadioModule} from '@angular/material/radio';


import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  FormsModule,
  ReactiveFormsModule
  
} from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { FlightService } from 'src/app/services/flight.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css'],
})
export class FilterComponent implements OnInit {
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private flightservice: FlightService
  ) {}

  form: FormGroup;

  // ngOnInit(): void {
  //   this.form = this.formBuilder.group({
  //     source: ["", Validators.required],
  //     destination: ["", Validators.required],
  //     type: ["", Validators.required],
  //     currency: ["", Validators.required]

  //   });
  // }

  controlOrigin = new FormControl('');
  controlDestination = new FormControl('');
  optionsOrigin: string[] = [];
  optionsDestination: string[] = [];
  filteredOriginOptions: Observable<string[]>;
  filteredDestinationOptions: Observable<string[]>;
  optionSelected: string;

  ngOnInit() {
    this.getOrigins();
  }

  private _filterOrigin(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.optionsOrigin.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }
  
  private _filterDestination(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.optionsDestination.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }

  private getOrigins() {
    this.flightservice.getOrigins().subscribe((data: any) => {
      console.log(data);
      this.optionsOrigin = data;
      this.filteredOriginOptions = this.controlOrigin.valueChanges.pipe(
        startWith(''),
        map((value) => this._filterOrigin(value || ''))
      );
    });
  }
  
  getDestination() {
    this.flightservice.getDestination(this.controlOrigin.value).subscribe((dataD: any) => {
      console.log(dataD);
      this.optionsDestination = dataD;
      this.filteredDestinationOptions = this.controlDestination.valueChanges.pipe(
        startWith(''),
        map((value) => this._filterDestination(value || ''))
      );
    });
  }

  executeSearch() {
    this.router.navigate(['']);
  }
}
