using AzureDataExplorerApp.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDataExplorerApp.Services
{
    public class TimeSeriesService : ITimeSeriesService
    {
        public TimeSeriesService(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        public async Task<ICollection<TimeSerieValueModel>> GetTimeSeries(string assetId, DateTime start, DateTime end)
        {
            return await Mediator.Send(new GetTimeSeriesRequestModel { AssetId = assetId, Start = start, End = end });
        }
    }
}
