using Application.Common.Interfaces;
using freecurrencyapi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrencyConverterService : ICurrencyConverterService
    {
        public Currency.Currency currencies { get; set; }
        public CurrencyConverterService()
        {
            Freecurrencyapi api = new Freecurrencyapi("rz48rPpP0rvNwpsDPIRCiPXTzEsEhth4Q4vJDaRs");

            currencies = JsonConvert.DeserializeObject<Currency.Currency>(api.Latest("USD"));
           
        }

        public decimal ConvertCurrency(decimal amount, string currency)
        {
          
            return amount * currencies.Data[currency];

           
        }
    }
}
