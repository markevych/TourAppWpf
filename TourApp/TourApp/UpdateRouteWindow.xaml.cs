using System.Collections.Generic;
using System.Windows;
using TourApp.BLL.Services;
using TourApp.DAL.Models;

namespace TourApp
{
    public partial class UpdateRouteWindow : Window
    {
        private readonly CountryService countryService;
        private readonly RouteService routeService;
        private readonly Route existingRoute;

        public UpdateRouteWindow()
        {
            InitializeComponent();

            countryService = new CountryService();
            routeService = new RouteService();

            InitializeInitialFields();
        }

        public UpdateRouteWindow(int existingRouteId)
        {
            InitializeComponent();

            countryService = new CountryService();
            routeService = new RouteService();

            this.existingRoute = routeService.GetById(existingRouteId);

            InitializeInitialFields();
            PrepopulateRouteInformation(existingRoute);
        }

        public void InitializeInitialFields()
        {
            var allCountries = countryService.GetAll();

            toCountriesList.ItemsSource = allCountries;
            toCountriesList.DisplayMemberPath = "Name";
            fromCountriesList.ItemsSource = allCountries;
            fromCountriesList.DisplayMemberPath = "Name";
        }

        public void PrepopulateRouteInformation(Route existingRoute)
        {
            var allCountries = countryService.GetAll();

            var toCountry = allCountries.Find(x => x.Id == existingRoute.ToCity.CountryId);
            toCountriesList.SelectedIndex = allCountries.IndexOf(toCountry);
            var fromCountry = allCountries.Find(x => x.Id == existingRoute.FromCity.CountryId);
            fromCountriesList.SelectedIndex = allCountries.IndexOf(fromCountry);

            var allCities = countryService.GetCitiesByCountryId(existingRoute.ToCity.CountryId);

            toCitiesList.ItemsSource = allCities;
            toCitiesList.DisplayMemberPath = "Name";
            var toCityIndex = allCities.IndexOf(allCities.Find(x => x.Id == existingRoute.ToCityId));
            toCitiesList.SelectedIndex = toCityIndex;

            allCities = countryService.GetCitiesByCountryId(existingRoute.FromCity.CountryId);

            fromCitiesList.ItemsSource = allCities;
            fromCitiesList.DisplayMemberPath = "Name";
            var fromCityIndex = allCities.IndexOf(allCities.Find(x => x.Id == existingRoute.FromCityId));
            fromCitiesList.SelectedIndex = fromCityIndex;

            startDatePicker.SelectedDate = existingRoute.StartDate;
            endDatePicker.SelectedDate = existingRoute.EndDate;
            priceInput.Text = existingRoute.Price.ToString();
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            dynamic fromCity = fromCitiesList.SelectedItem;
            int fromCityId = fromCity.Id;

            dynamic toCity = toCitiesList.SelectedItem;
            int toCityId = toCity.Id;

            var route = new Route
            {
                Id = existingRoute?.Id ?? routeService.GetId(),
                FromCityId = fromCityId,
                ToCityId = toCityId,
                StartDate = startDatePicker.SelectedDate.GetValueOrDefault(),
                EndDate = endDatePicker.SelectedDate.GetValueOrDefault(),
                Price = double.Parse(priceInput.Text),
                IsFlight = true
            };

            if (existingRoute == null)
                routeService.Create(route);
            else
                routeService.Update(route);

            this.Close();
        }

        private void OnCountryFromSelect(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dynamic fromCountry = fromCountriesList.SelectedItem;
            int fromCountryId = fromCountry.Id;

            var allCities = countryService.GetCitiesByCountryId(fromCountryId);

            fromCitiesList.ItemsSource = allCities;
            fromCitiesList.DisplayMemberPath = "Name";
        }

        private void OnCountryToSelect(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dynamic toCountry = toCountriesList.SelectedItem;
            int toCountryId = toCountry.Id;

            var allCities = countryService.GetCitiesByCountryId(toCountryId);

            toCitiesList.ItemsSource = allCities;
            toCitiesList.DisplayMemberPath = "Name";
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (existingRoute == null)
                MessageBox.Show("Ви ще не створили шлях, тому його не можна видалити");
            else
                routeService.Remove(existingRoute);

            this.Close();
        }
    }
}
