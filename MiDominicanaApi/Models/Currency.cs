using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiDominicanaApi.Models
{
    public class Currency
    {
        public Currency()
        {
        }

        public Currency(string name, decimal purchase, decimal sale)
        {
            Name = name;
            Purchase = purchase;
            Sale = sale;
        }

        public string Name { get; set; }
        public decimal Purchase { get; set; }
        public decimal Sale { get; set; }
    }
}
