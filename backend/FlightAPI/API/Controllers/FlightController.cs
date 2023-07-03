using Application.Common.Models;
using Application.Flight.Queries.GetFlight;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Authorize]
    public class FlightController : ApiControllerBase
    {

       /// <summary>
       /// Get flights.
       /// </summary>
       /// <param name="query"></param>
       /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<Journey>>>> GetFlight([FromQuery] GetFlightQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
