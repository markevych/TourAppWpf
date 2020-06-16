using System;
using TourApp.DAL.Models;

namespace TourApp.VM
{
    public class RouteDataGridItemVM
    {
        public int Id { get; set; }
        public string FromCountry { get; set; }
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public string ToCountry { get; set; }
        public string Transport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }

        public RouteDataGridItemVM(Route route)
        {
            Id = route.Id;
            FromCountry = route.FromCity.Country.Name;
            FromCity = route.FromCity.Name;
            ToCountry = route.ToCity.Country.Name;
            ToCity = route.ToCity.Name;
            Transport = route.IsFlight ? "Літак" : "Автобус";
            StartDate = route.StartDate;
            EndDate = route.EndDate;
            Price = route.Price;
        }
    }
}
