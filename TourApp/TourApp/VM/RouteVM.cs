using TourApp.BLL.Extensions;
using TourApp.DAL.Models;

namespace TourApp.VM
{
    public class RouteVM : Route
    {
        public string DisplayValue { get; set; }

        public RouteVM(Route route)
        {
            Id = route.Id;
            FromCity = route.FromCity;
            ToCity = route.ToCity;
            Price = route.Price;
            StartDate = route.StartDate;
            EndDate = route.EndDate;
            IsFlight = route.IsFlight;
            DisplayValue = route.GetRouteDescription();
        }
    }
}
