import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { FlightService } from './flight.service';

let service: FlightService;

beforeEach(() => {
  TestBed.configureTestingModule({ providers: [FlightService], imports: [HttpClientTestingModule] });
});

it('should create', () => {
  service = TestBed.inject(FlightService);
  expect(service).toBeTruthy();
});
