using Application.Flight.Queries.GetFlight;
using FluentValidation;

namespace Application.Shipment.Queries.GetShipment
{
    public class GetFlightQueryValidator : AbstractValidator<GetFlightQuery>
    {
        public GetFlightQueryValidator()
        {
            RuleFor(query => query.Origin).NotEmpty().WithMessage("Origin is required");
            RuleFor(query => query.Destination).NotEmpty().WithMessage("Destination is required");            
        }
    }
}
