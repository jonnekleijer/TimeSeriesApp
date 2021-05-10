using Kusto.Data;
using Kusto.Data.Common;
using Kusto.Data.Net.Client;
using MediatR;
using System;
using System.Collections.Generic;

namespace AzureDataExplorerApp.Services.Interfaces
{
    public class GetTimeSeriesRequestModel : IRequest<ICollection<TimeSerieValueModel>>
    {
    }

    public class Handler : RequestHandler<GetTimeSeriesRequestModel, ICollection<TimeSerieValueModel>>
    {
        public Handler()
        {
        }
        protected override ICollection<TimeSerieValueModel> Handle(GetTimeSeriesRequestModel request)
        {
            const string Cluster = "https://help.kusto.windows.net";
            const string Database = "Samples";
            var connectionBuilder = new KustoConnectionStringBuilder(Cluster, Database).WithAadAzCliAuthentication();

            using var queryProvider = KustoClientFactory.CreateCslQueryProvider(connectionBuilder);
            var query = "SamplePowerRequirementHistorizedData | limit 10";
            var requestId = Guid.NewGuid().ToString();
            var clientRequestProperties = new ClientRequestProperties() { ClientRequestId = requestId };

            using var reader = queryProvider.ExecuteQuery(query, clientRequestProperties);
            var timeSeries = new List<TimeSerieValueModel>();
            while (reader.Read())
            {
                var timeSerieValue = new TimeSerieValueModel {
                    DateTime = reader.GetDateTime(0),
                    Value = reader.GetDouble(4)
                };
                timeSeries.Add(timeSerieValue);
            }
            return timeSeries;
        }
    }
}