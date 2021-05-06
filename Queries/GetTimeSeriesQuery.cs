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
            return new List<TimeSerieValueModel>() { new TimeSerieValueModel
            {
                TimeStamp = DateTime.Now.Ticks,
                Value = 1
            } };
        }
    }
}