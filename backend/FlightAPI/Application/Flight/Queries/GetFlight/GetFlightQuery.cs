using Application.Common.ExternalServices.NewshoreFlights.Response;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Dto;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Flight.Queries.GetFlight
{
    public class GetFlightQuery : IRequest<ServiceResult<List<Journey>>>
    {
        public string Origin { get; set; }

        public string Destination { get; set; }
    }

    public class GetFlightQueryHandler : IRequestHandler<GetFlightQuery, ServiceResult<List<Journey>>>
    {
        private readonly IFlightService _flightService;
        private readonly ICurrencyConverterService _currencyConverterService;
        private readonly IMapper _mapper;

        public GetFlightQueryHandler(IFlightService service, IMapper mapper, ICurrencyConverterService currencyConverterService)
        {
            _currencyConverterService = currencyConverterService;
            _flightService = service;
            _mapper = mapper;
        }
        public async Task<ServiceResult<List<Journey>>> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _flightService.GetFlights(cancellationToken);
                var flights = SearchFlights(request.Origin, request.Destination, result.Data, new HashSet<string>());
                return ServiceResult.Success(flights);

            }
            catch(Exception ex)
            {
                return ServiceResult.Failed<List<Journey>>(ServiceError.ServiceProvider);
            }
           
        }

        private List<Journey> SearchFlights(string origin, string destination, List<FlightResponse> flights, HashSet<string> visited)
        {
            List<Journey> matchingFlights = new List<Journey>();

            // Buscar vuelos directos
            matchingFlights.AddRange(flights.Where(flight => flight.DepartureStation == origin && flight.ArrivalStation == destination)
                .Select(flight => _mapper.Map<Journey>(flight)));
          
            if(matchingFlights.Count == 0) 
            {
                visited.Add(origin); // Marcar el origen como visitado
                // Buscar vuelos con conexiones
                foreach (FlightResponse flight in flights.Where(f => f.DepartureStation == origin && !visited.Contains(f.ArrivalStation)))
                {
                    List<Journey> connectingFlights = SearchFlights(flight.ArrivalStation, destination, flights, visited);

                    matchingFlights.AddRange(connectingFlights.Select(connectingJourney =>
                    {
                        var journey = _mapper.Map<Journey>(flight);
                        journey.Destination = destination;
                        journey.Price += connectingJourney.Price;
                        journey.Flights.AddRange(connectingJourney.Flights);
                        return journey;
                    }));
                }

                visited.Remove(origin); // Restaurar el estado de visitado del origen
            }

            foreach (var flight in matchingFlights)
            {
                flight.PriceCAD = _currencyConverterService.ConvertCurrency(flight.Price, "CAD");
                flight.PriceAUD = _currencyConverterService.ConvertCurrency(flight.Price, "AUD");

                foreach (var nestedFlight in flight.Flights)
                {
                    nestedFlight.PriceCAD = _currencyConverterService.ConvertCurrency(nestedFlight.Price, "CAD");
                    nestedFlight.PriceAUD = _currencyConverterService.ConvertCurrency(nestedFlight.Price, "AUD");
                }
            }

            return matchingFlights;
        }

  

    }
}
