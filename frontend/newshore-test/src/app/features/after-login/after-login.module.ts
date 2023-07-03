import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '@shared/shared.module';

import { AfterLoginRoutingModule } from './after-login-routing.module';
import { AfterLoginComponent } from './after-login.component';
import { FlightFormComponent } from '@shared/components/flight-form/flight-form.component';
import { FlightResultsComponent } from '@shared/components/flight-results/flight-results.component';

@NgModule({
  declarations: [AfterLoginComponent],
  imports: [CommonModule, AfterLoginRoutingModule, SharedModule, FlightFormComponent, FlightResultsComponent],
})
export class AfterLoginModule {}
