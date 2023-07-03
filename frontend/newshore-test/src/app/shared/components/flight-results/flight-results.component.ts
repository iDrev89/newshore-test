import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { CommonModule } from '@angular/common';
import { MatDividerModule } from '@angular/material/divider';
import { FlightService } from '@core/services/flight-service/flight.service';
import { MatSelectModule } from '@angular/material/select';
import { Subject, takeUntil } from 'rxjs';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-flight-results',
  templateUrl: './flight-results.component.html',
  styleUrls: ['./flight-results.component.scss'],
  imports: [
    MatDatepickerModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    MatCardModule,
    MatExpansionModule,
    CommonModule,
    MatDividerModule,
    MatSelectModule,
    FormsModule,
  ],
  standalone: true,
})
export class FlightResultsComponent implements OnInit, OnDestroy {
  flightData: Journey[] | undefined;
  private destroyed$ = new Subject();
  selectedOptions: string[] = [];
  constructor(private flightsService: FlightService) {}

  ngOnInit(): void {
    this.flightsService.flightsData$.pipe(takeUntil(this.destroyed$)).subscribe((response: Journey[]) => {
      this.flightData = response;
    });
  }

  ngOnDestroy(): void {
    this.destroyed$.next(null);
    this.destroyed$.complete();
  }
}
