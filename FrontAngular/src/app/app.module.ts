import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './main/header/header.component';
import { DCXResultComponent } from './main/dcxresult/dcxresult.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MaterialModule } from './material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FilterComponent } from './main/filter/filter.component';
import { HttpClientModule } from '@angular/common/http';
import { MainlandingComponent } from './mainlanding/mainlanding.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    DCXResultComponent,
    FilterComponent,
    MainlandingComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
