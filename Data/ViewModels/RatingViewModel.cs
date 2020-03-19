using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ViewModels
{
    public class RatingViewModel
    {
        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
