using Application.Common.ExternalServices.NewshoreFlights.Response;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto
{
    public class JourneyDto: IMapFrom<FlightResponse>
    {
        public string Origin { get; set; }

        public string Destination { get; set; }

        public double Price { get; set; }

        public List<Domain.Entities.Flight> Flights { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FlightResponse, Journey>()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src.DepartureStation))
                .ForMember(dest => dest.Destination, opt => opt.MapFrom(src => src.ArrivalStation))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Convert.ToDecimal(src.Price)))
                .ForMember(dest => dest.Flights, opt => opt.MapFrom(src => new List<Domain.Entities.Flight>
                {
                    new Domain.Entities.Flight
                    {
                        Origin = src.DepartureStation,
                        Destination = src.ArrivalStation,
                        Price = Convert.ToDecimal(src.Price),
                        Transport = new Transport
                        {
                            FlightCarrier = src.FlightCarrier.ToString(),
                            FlightNumber = src.FlightNumber
                        }
                    }
                }));

        }
    }
}
