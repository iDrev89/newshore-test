using Application.Common.ExternalServices.NewshoreFlights.Response;
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IFlightService
    {
        Task<ServiceResult<List<FlightResponse>>> GetFlights(CancellationToken cancellationToken);
    }
}
