interface Flight {
  origin: string;
  destination: string;
  price: number;
  priceCAD: number;
  priceAUD: number;
  transport: {
    flightCarrier: string;
    flightNumber: string;
  };
}
interface FlightResponse{
  data: Journey[];
  error: string;
  succeeded: string;
}
interface Journey {
  origin: string;
  destination: string;
  price: number;
  priceCAD: number;
  priceAUD: number;
  flights: Flight[];
}

interface FlightData {
  Journey: Journey;
}
