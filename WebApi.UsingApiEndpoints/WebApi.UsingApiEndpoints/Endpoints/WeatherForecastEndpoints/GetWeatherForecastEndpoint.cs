using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.UsingApiEndpoints.Endpoints.WeatherForecastEndpoints
{
    public class GetWeatherForecastEndpoint : EndpointBaseSync
        .WithoutRequest
        .WithResult<IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GetWeatherForecastEndpoint> _logger;

        public GetWeatherForecastEndpoint(ILogger<GetWeatherForecastEndpoint> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/WeatherForecast")]
        public override IEnumerable<WeatherForecast> Handle()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
