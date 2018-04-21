import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BusyModule } from 'angular2-busy';
import { NgModule } from '@angular/core';

import { appRoutes } from './app.routing';

import { AppComponent } from './app.component';
import { ShipmentsSearchComponent } from './shipments/shipmentsSearch.component';
import { ShipmentsDetailsComponent } from './shipments/shipmentsDetails.component';
import { ShipmentsService } from './shipments/shipmentsService';
import { BoolTextPipe } from './boolTextPipe';

@NgModule({
  declarations: [
    AppComponent,
    ShipmentsSearchComponent,
    ShipmentsDetailsComponent,
    BoolTextPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    BusyModule
  ],
  providers: [ShipmentsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
