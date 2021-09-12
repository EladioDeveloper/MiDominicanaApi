using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiDominicanaApi.Models
{
    public class Currency
    {
        public string Bank { get; set; }
        public byte Rate { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
    }
}
