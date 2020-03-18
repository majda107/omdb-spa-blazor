using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMDbPW1.ViewModels
{
    public class MovieDetailViewModel
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("Rated")]
        public string Rated { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("imdbRating")]
        public string Rating { get; set; }

        [JsonProperty("imdbID")]
        public string ID { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }
    }
}
