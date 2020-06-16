using System.Collections.Generic;
using System.Linq;
using TourApp.DAL.Context;
using TourApp.DAL.Interfaces;
using TourApp.DAL.Models;
using TourApp.DAL.Repositories;

namespace TourApp.BLL.Services
{
    public class CountryService
    {
        private readonly ApplicationContext applicationContext;
        private readonly IRepository<Country> countries;
        private readonly IRepository<City> cities;

        public CountryService()
        {
            applicationContext = new ApplicationContext();
            countries = new Repository<Country>(applicationContext);
            cities = new Repository<City>(applicationContext);
        }

        public List<Country> GetAll() =>
            countries.Get().ToList();

        public List<City> GetCitiesByCountryId(int countryId) =>
            cities.Get(x => x.CountryId == countryId).ToList();
    }
}
