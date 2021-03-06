﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KnowWeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Cities = new[]
        {
            "Delhi", "Varanasi", "Banglore", "Culcutta", "Mubmai", "Kerala", "Rajasthan"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                City = Cities[rng.Next(Cities.Length)],
                Summary = Summaries[rng.Next(Summaries.Length)]
            }) 
            .ToArray();
        }

        [HttpGet("{id}" , Name="Get()")]
        public IEnumerable<WeatherForecast> Get(string id)
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                City = Cities[rng.Next(Cities.Length)],
                Summary = Summaries[rng.Next(Summaries.Length)]
            }) .Where(s => s.Summary== id)
            .ToArray();
        }

    }
}
