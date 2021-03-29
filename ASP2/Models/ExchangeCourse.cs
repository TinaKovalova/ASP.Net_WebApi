using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP2.Models
{
    public class ExchangeCourse
    {
        [JsonProperty("ccy")]
        public string Ccy { get; set; }

        [JsonProperty("buy")]
        public double Buy { get; set; }
        [JsonProperty("sale")]
        public double Sale { get; set; }
    }
}