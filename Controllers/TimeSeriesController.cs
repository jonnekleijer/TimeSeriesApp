using AzureDataExplorerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDataExplorerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSeriesController : ControllerBase
    {
        private readonly ITimeSeriesService _timeSeriesService;
        private readonly ILogger<TimeSeriesController> _logger;

        public TimeSeriesController(ITimeSeriesService timeSeriesService, ILogger<TimeSeriesController> logger)
        {
            _timeSeriesService = timeSeriesService;
            _logger = logger;
        }

        /// <summary>
        /// Get timeseries
        /// </summary>
        /// <param name="assetId">Id of your asset</param>
        /// <param name="start">Start of timeseries</param>
        /// <param name="end">End of timeseries</param>
        /// <response code="200">Successful response - returns a list of timeseries values</response>
        /// <returns></returns>
        [HttpGet("{assetId}")]
        public async Task<ICollection<TimeSerieValueModel>> Get(string assetId, DateTime start, DateTime end)
        {
            return await _timeSeriesService.GetTimeSeries(assetId, start, end);
        }
    }
}
