using System;
using System.Collections.Generic;
using System.Linq;
using YandexTrains.ResponseModels.TripPlanner;

namespace YandexTrains.Models.TripPlanner
{
    public class Trip
    {
        public IEnumerable<Step> Steps { get; set; }

        public Trip(TripResponse tripResponseModel)
        {
            Steps = tripResponseModel.Legs.Select(leg => new Step(leg));
        }

        public Trip()
        {
        }
    }
}
