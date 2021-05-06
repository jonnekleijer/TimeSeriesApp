using AzureDataExplorerApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDataExplorerApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSeriesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ITimeSeriesService _timeSeriesService;
        private readonly ILogger<TimeSeriesController> _logger;

        public TimeSeriesController(ITimeSeriesService timeSeriesService, ILogger<TimeSeriesController> logger)
        {
            _timeSeriesService = timeSeriesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ICollection<TimeSerieValueModel>> Get()
        {
            return await _timeSeriesService.GetTimeSeries();
        }
    }
}
