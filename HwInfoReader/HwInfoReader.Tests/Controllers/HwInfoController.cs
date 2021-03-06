﻿using HwInfoReader.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HwInfoReader.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HwInfoController : ControllerBase
    {
        private readonly IHwInfoReader _hwInfoReader;

        public HwInfoController(IHwInfoReader hwInfoReader)
        {
            _hwInfoReader = hwInfoReader;
        }

        [Route("details")]
        [HttpGet]
        public IActionResult GetDetails()
        {
            var sensorNames = _hwInfoReader.ReadSensors()
                .Select(s => s.szSensorNameUser);

            var groupedReadings = _hwInfoReader.ReadSensorReadings()
                .GroupBy(g => g.tReading)
                .Select(s => new { Sensor = s.Key.ToString(), data = s.ToList() });

            return Ok(new { AvailableSensors = sensorNames, SensorReadings = groupedReadings });
        }
    }
}
