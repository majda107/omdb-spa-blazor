using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OMDbPW1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OMDbPW1.Data.Movie
{
    public class MovieService
    {
        private const string KEY = "c376411e";
        private string ENDPOINT = $"http://www.omdbapi.com/?apikey={KEY}";

        private readonly HttpClient _http;
        public MovieService(HttpClient http)
        {
            this._http = http;
        }

        public async Task<IEnumerable<MovieViewModel>> SearchAsync(string name, string type = null, int year = -1)
        {
            var requestUrl = $"{this.ENDPOINT}&s={name}";
            if (type != null) requestUrl += $"&type={type}";
            if (year >= 0) requestUrl += $"&y={year}";

            var result = await this._http.GetAsync(requestUrl);

            if (result.StatusCode != System.Net.HttpStatusCode.OK) return null;

            var content = await result.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            if (!json.ContainsKey("Search")) return null;

            var movies = json["Search"].ToObject<IEnumerable<MovieViewModel>>();
            return movies;
        }

        public async Task<MovieDetailViewModel> GetDetailAsync(MovieViewModel movie) => await this.GetDetailAsync(movie.ID);
        public async Task<MovieDetailViewModel> GetDetailAsync(string id)
        {
            var requestUrl = $"{this.ENDPOINT}&i={id}";

            var result = await this._http.GetAsync(requestUrl);
            if (result.StatusCode != System.Net.HttpStatusCode.OK) return null;

            var content = await result.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);

            // CHECK FOR VALID MOVIE...
            if (json.ContainsKey("Response") && json["Response"].ToString() == "False") return null;

            //if(json.ContainsKey("Response"))
            //{
            //    json["Response"].ToString
            //}

            return json.ToObject<MovieDetailViewModel>();
        }
    }
}
