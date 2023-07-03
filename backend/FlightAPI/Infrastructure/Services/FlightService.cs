using Application.Common.ExternalServices.NewshoreFlights.Response;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FlightService: IFlightService
    {
        public readonly IHttpClientHandler _httpClientHandler;
        public readonly IMapper _mapper;

        private string ClientAPI { get; set; } = "newshore-api";

        public FlightService(IHttpClientHandler httpClientHandler, IMapper mapper)
        {
            _mapper = mapper;
            _httpClientHandler = httpClientHandler;
        }

        public async Task<ServiceResult<List<FlightResponse>>> GetFlights(CancellationToken cancellationToken)
        {            
            return await _httpClientHandler.GenericRequest<List<FlightResponse>>(ClientAPI, "/api/flights/2", cancellationToken, Domain.Enums.MethodType.Get);
        }

       
    }
}
