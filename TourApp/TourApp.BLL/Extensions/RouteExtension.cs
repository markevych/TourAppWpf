using TourApp.DAL.Models;

namespace TourApp.BLL.Extensions
{
    public static class RouteExtension
    {
        public static string GetRouteDescription(this Route route) =>
            $"{route.FromCity.Country.Name} ({route.FromCity.Name}) {route.StartDate} --> {route.ToCity.Country.Name} ({route.ToCity.Name}) {route.EndDate} {route.GetTransport()} {route.Price} грн.";

        public static string GetTransport(this Route route) =>
            route.IsFlight ? "Літак" : "Автобус";
    }
}
