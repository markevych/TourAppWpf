using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourApp.BLL.Extensions;
using TourApp.BLL.Services;
using TourApp.VM;

namespace TourApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CountryService countryService;
        private readonly RouteService routeService;

        public MainWindow()
        {
            InitializeComponent();

            countryService = new CountryService();
            routeService = new RouteService();

            InitializeCountries();
        }

        public void InitializeCountries()
        {
            var countries = countryService.GetAll();

            foreach (var item in countries)
            {
                countriesList.Items.Add(item);
            }

            countriesList.DisplayMemberPath = "Name";
        }

        private void SelectCountry(object sender, SelectionChangedEventArgs e)
        {
            routesList.Items.Clear();

            dynamic listBoxItem = sender;
            int countryId = listBoxItem.SelectedValue.Id;
            var routes = routeService.GetByCountryName(countryId);

            foreach (var item in routes)
            {
                routesList.Items.Add(new RouteVM(item));
            }

            routesList.DisplayMemberPath = "DisplayValue";
        }

        private void SelectRoute(object sender, SelectionChangedEventArgs e)
        {
            transportName.Text = null;
            priceOfRoute.Text = null;
            startDate.Text = null;
            startTime.Text = null;

            dynamic listBoxItem = sender;

            if (listBoxItem?.SelectedValue == null) return;

            bool isFlight = listBoxItem.SelectedValue.IsFlight;
            transportName.Text = isFlight ? "Літак" : "Автобус";

            double price = listBoxItem.SelectedValue.Price;
            priceOfRoute.Text = price.ToString();

            DateTime routeStartDate = listBoxItem.SelectedValue.StartDate;
            startDate.Text = routeStartDate.ToString();

            DateTime routeEndDate = listBoxItem.SelectedValue.EndDate;
            startTime.Text = routeEndDate.ToString();
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            routesList.Items.Clear();

            var allRoutes = routeService.GetAll();

            if (needCountryNameFilter.IsChecked.GetValueOrDefault())
                allRoutes = allRoutes.Where(x => x.ToCity.Country.Name == countryNameFilter.Text).ToList();

            if (needTypeFilter.IsChecked.GetValueOrDefault())
            {
                if (needToIncludeFlights.IsChecked.GetValueOrDefault() && !needToIncludeBuses.IsChecked.GetValueOrDefault())
                    allRoutes = allRoutes.Where(x => x.IsFlight).ToList();
                else if (!needToIncludeFlights.IsChecked.GetValueOrDefault() && needToIncludeBuses.IsChecked.GetValueOrDefault())
                    allRoutes = allRoutes.Where(x => !x.IsFlight).ToList();
            }

            if (needPriceFilter.IsChecked.GetValueOrDefault())
                allRoutes = allRoutes.Where(x => x.Price >= double.Parse(lowLimitPrice.Text) && x.Price <= double.Parse(hightLimitPrice.Text)).ToList();

            if (needDateFilter.IsChecked.GetValueOrDefault())
                allRoutes = allRoutes.Where(x => x.StartDate >= DateTime.Parse(lowLimitDate.Text) && x.EndDate <= DateTime.Parse(highLimitDate.Text)).ToList();

            allRoutes.ForEach(x => routesList.Items.Add(new RouteVM(x)));
            routesList.DisplayMemberPath = "DisplayValue";
        }
    }
}
