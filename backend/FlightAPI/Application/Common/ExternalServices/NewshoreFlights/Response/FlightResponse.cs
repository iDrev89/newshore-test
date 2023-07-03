using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ExternalServices.NewshoreFlights.Response
{
    public class FlightResponse
    {
        [JsonProperty("departureStation")]
        public string DepartureStation { get; set; }

        [JsonProperty("arrivalStation")]
        public string ArrivalStation { get; set; }

        [JsonProperty("flightCarrier")]
        public string FlightCarrier { get; set; }

        [JsonProperty("flightNumber")]        
        public string FlightNumber { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }
    }

    public enum FlightCarrier { Co, Es, Mx };
}
