using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Flight
    {
        public string Origin { get; set; }
        public string Destination { get; set; } 

        public decimal Price { get; set;  }

        public decimal PriceCAD { get; set; }

        public decimal PriceAUD { get; set; }
        public Transport Transport { get; set; }

    }
}
