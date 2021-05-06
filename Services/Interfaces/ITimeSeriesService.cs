using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureDataExplorerApp.Services.Interfaces
{
    public interface ITimeSeriesService
    {
        Task<ICollection<TimeSerieValueModel>> GetTimeSeries();
    }
}
