using System.Windows;

namespace TourApp
{
    public partial class InitialWindow : Window
    {
        public InitialWindow()
        {
            InitializeComponent();
        }

        private void OpenMainWindow(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            
            this.Close();
        }

        private void OpenAdminWindow(object sender, RoutedEventArgs e)
        {
            var loginWindow = new AdminLoginWindow();
            loginWindow.Show();

            this.Close();
        }
    }
}
