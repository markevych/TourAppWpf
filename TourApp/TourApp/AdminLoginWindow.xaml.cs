using System.Windows;
using TourApp.BLL.Services;

namespace TourApp
{
    public partial class AdminLoginWindow : Window
    {
        private readonly UserService userService;

        public AdminLoginWindow()
        {
            InitializeComponent();

            userService = new UserService();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            var isLogined = userService.IsLogined(loginInput.Text, passwordInput.Password);

            if (isLogined)
            {
                var adminDashboardWindow = new AdminDashboardWindow();
                adminDashboardWindow.Show();

                this.Close();
            } 
            else
            {
                MessageBox.Show("Введений логін або пароль невірний. Спробуйте знову.");
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow();
            registerWindow.Show();

            this.Close();
        }
    }
}
