import { Component } from '@angular/core';
import { AbstractControl, FormGroup, ReactiveFormsModule, ValidationErrors, Validators } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlightService } from '@core/services/flight-service/flight.service';
import { FormBuilder } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
@Component({
  selector: 'app-flight-form',
  templateUrl: './flight-form.component.html',
  styleUrls: ['./flight-form.component.scss'],
  imports: [
    MatDatepickerModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    ReactiveFormsModule,
    NgxMaskModule,
  ],
  standalone: true,
})
export class FlightFormComponent {
  constructor(private flightService: FlightService, private fb: FormBuilder) {}

  flightFormGroup = this.fb.group(
    {
      origin: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(3)]],
      destination: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(3)]],
    },
    { validators: this.mismatchValidator }
  );

  mismatchValidator(g: FormGroup): ValidationErrors | null {
    const origin = g.get('origin')!.value;
    const destination = g.get('destination')!.value;

    if (origin === destination) {
      return { mismatch: true };
    }

    return null;
  }

  onSubmit(): void {
    const data = this.flightFormGroup.getRawValue();
    this.flightService.searchFlights(data);
  }
}
