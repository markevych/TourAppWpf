using System.Collections.Generic;
using System.Linq;
using TourApp.DAL.Context;
using TourApp.DAL.Interfaces;
using TourApp.DAL.Models;
using TourApp.DAL.Repositories;

namespace TourApp.BLL.Services
{
    public class RouteService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IRepository<Route> routes;
        private readonly IRepository<Country> countries;
        private readonly IRepository<City> cities;

        public RouteService()
        {
            applicationContext = new ApplicationContext();

            routes = new Repository<Route>(applicationContext);
            countries = new Repository<Country>(applicationContext);
            cities = new Repository<City>(applicationContext);
        }

        public List<Route> GetAll() =>
            routes.GetWithInclude(
                x => x.FromCity,
                x => x.FromCity.Country,
                x => x.ToCity,
                x => x.ToCity.Country).ToList();

        public List<Route> GetByCountryName(int countryId)
        {
            var citiesFromCountry = cities.Get(x => x.CountryId == countryId).ToList();

            return routes.GetWithInclude(
                x => citiesFromCountry.Any(c => c.Id == x.ToCityId),
                x => x.FromCity,
                x => x.FromCity.Country,
                x => x.ToCity,
                x => x.ToCity.Country).ToList();
        }

        public void Create(Route route) =>
            routes.Create(route);

        public void Update(Route route) =>
            routes.Update(route);

        public void Remove(Route route) =>
            routes.Remove(route);

        public int GetId() =>
            routes.Get().Count() + 1;

        public Route GetById(int id) =>
            routes.GetWithInclude(
                x => x.Id == id,
                x => x.FromCity,
                x => x.FromCity.Country,
                x => x.ToCity,
                x => x.ToCity.Country).FirstOrDefault();
    }
}
