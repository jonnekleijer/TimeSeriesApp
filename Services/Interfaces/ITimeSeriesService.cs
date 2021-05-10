using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDataExplorerApp.Services.Interfaces
{
    public interface ITimeSeriesService
    {
        Task<ICollection<TimeSerieValueModel>> GetTimeSeries(string assetId, DateTime start, DateTime end, double interval = 0);
    }
}
