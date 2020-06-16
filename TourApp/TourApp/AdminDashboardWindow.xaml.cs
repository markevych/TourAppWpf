using System.ComponentModel;
using System.Linq;
using System.Windows;
using TourApp.BLL.Services;
using TourApp.DAL.Models;
using TourApp.VM;

namespace TourApp
{
    public partial class AdminDashboardWindow : Window
    {
        private readonly RouteService routeService;

        public AdminDashboardWindow()
        {
            InitializeComponent();

            routeService = new RouteService();

            InitializeRoutes();
        }

        private void InitializeRoutes()
        {
            var allRoutes = routeService.GetAll().Select(x => new RouteDataGridItemVM(x));

            routesList.AutoGenerateColumns = true;
            routesList.ItemsSource = allRoutes;
        }

        private void Update(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            dynamic senderDynamic = sender;

            if (senderDynamic.SelectedValue == null) return;

            int selectedRouteId = senderDynamic.SelectedValue.Id; 
            var updateRouteWindow = new UpdateRouteWindow(selectedRouteId);
            updateRouteWindow.Show();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var updateRouteWindow = new UpdateRouteWindow();
            updateRouteWindow.Show();
        }

        private void Review(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        private void Refresh(object sender, RoutedEventArgs e) =>
            InitializeRoutes();
    }
}
