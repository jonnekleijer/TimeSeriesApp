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

        public async Task<ICollection<TimeSerieValueModel>> GetTimeSeries(string assetId, DateTime start, DateTime end, double interval)
        {
            if (interval == 0)
            {
                var period = end - start;
                interval = CalculateInterval(period);
            }

            return await Mediator.Send(new GetTimeSeriesRequestModel {
                AssetId = assetId, Start = start, End = end, Interval = interval
            });
        }

        private static double CalculateInterval(TimeSpan period)
        {
            double interval;
            if (period > new TimeSpan(30, 0, 0, 0))
            {
                interval = new TimeSpan(1, 0, 0, 0).TotalSeconds;
            }
            else if (period > new TimeSpan(7, 0, 0, 0))
            {
                interval = new TimeSpan(1, 0, 0).TotalSeconds;
            }
            else
            {
                interval = new TimeSpan(0, 5, 0).TotalSeconds;
            }

            return interval;
        }
    }
}
