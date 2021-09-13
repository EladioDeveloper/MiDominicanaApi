//using Microsoft.AspNetCore.Http;
using System.Web;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MiDominicanaApi.Models
{
    public class Province
    {
        [JsonProperty("id")]
        public int Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("surface")]
        public double Surface { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }

        [JsonProperty("density")]
        public int Density { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }
    }
}
