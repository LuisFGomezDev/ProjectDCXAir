import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatRadioModule } from '@angular/material/radio';

import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';
import { Observable, map, startWith } from 'rxjs';
import { FlightService } from 'src/app/services/flight.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
})
export class FilterComponent implements OnInit {
  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private flightservice: FlightService
  ) {}

  form: FormGroup;

  optionsOrigin: string[] = [];
  optionsDestination: string[] = [];
  optionsCurrencies: string[] = ["USD", "COP", "MXN", "CAD", "EUR"];

  filteredOriginOptions: Observable<string[]>;
  filteredDestinationOptions: Observable<string[]>;
  filteredCurrencyOptions: Observable<string[]>;

  selectedOption: string;
  flightsdetail: any[] ;
  roundtripdetails: any;

  ngOnInit() {
    this.form = this.formBuilder.group({
      controlOrigin: ['', Validators.required],
      controlDestination: ['', Validators.required],
      controlCurrency: ['', Validators.required],
      selectedOption: ['', Validators.required],
    });
    this.getOrigins();
    this.getDestination();
    this.getCurrencies();

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
  private _filterCurrency(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.optionsCurrencies.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }
  
  private getOrigins() {
    this.flightservice.getOrigins().subscribe((data: any) => {
      console.log(data);
      this.optionsOrigin = data;
      this.filteredOriginOptions = this.form.controls["controlOrigin"].valueChanges.pipe(
        startWith(''),
        map((value) => this._filterOrigin(value || ''))
      );
    });
  }

  public getDestination() {
    this.flightservice.getDestination().subscribe((dataD: any) => {
      console.log(dataD);
      this.optionsDestination = dataD;
      this.filteredDestinationOptions =
      this.form.controls["controlDestination"].valueChanges.pipe(
          startWith(''),
          map((value) => this._filterDestination(value || ''))
        );
    });
  }

  private getCurrencies() {
      this.filteredCurrencyOptions = this.form.controls["controlCurrency"].valueChanges .pipe(
        startWith(''),
        map((value) => this._filterCurrency(value || ''))
      );
  }

  
  executeSearch() {
    if (this.form.controls['selectedOption'].value == 1) {
      this.flightservice
        .getOneWayFligth(
          this.form.controls['controlOrigin'].value,
          this.form.controls['controlDestination'].value,
          this.form.controls["controlCurrency"].value
        )
        .subscribe((data: any) => {
          this.flightsdetail = data;
        });
    } else if (this.form.controls['selectedOption'].value == 2) {
      this.flightservice
        .getRoundTripFligth(
          this.form.controls['controlOrigin'].value,
          this.form.controls['controlDestination'].value,
          this.form.controls["controlCurrency"].value
        )
        .subscribe((data: any) => {
          this.roundtripdetails = data;
        });
    }
  }
}