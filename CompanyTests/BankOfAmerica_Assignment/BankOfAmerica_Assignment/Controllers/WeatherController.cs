using BankOfAmerica_Assignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BankOfAmerica_Assignment.Controllers
{
    public class WeatherController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> City(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(AppConstants.str_BaseUrl);
                    var response = await client.GetAsync($"/data/2.5/forecast?q={city}&appid={AppConstants.str_AppId}&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<openWeatherResponse>(stringResult);
                    return Ok(new
                    {
                        summary = rawWeather.list,
                        city = rawWeather.city.name
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }
    }
}
