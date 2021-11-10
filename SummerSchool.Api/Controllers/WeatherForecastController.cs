﻿using EF.Dal.EfStructures;
using EF.Dal.Repos;
using EF.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummerSchool.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SummerSchool.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IAppLogging<WeatherForecastController> _logger;

        public WeatherForecastController(IAppLogging<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogAppWarning("This is a test");

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public IEnumerable<Car> FromDalForTest()
        {
            _logger.LogAppWarning("This is a test");

            var carRepo = new CarRepo(new ApplicationDbContextFactory().CreateDbContext(null));

            return carRepo.GetAllIgnoreQueryFilters();
        }
    }
}