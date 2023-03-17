using System.Windows;

namespace PasswordsTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var loginResource = Properties.UserSettings.Default.UserLogin;
            var passwordResource = Properties.UserSettings.Default.UserPassword;

            if (string.IsNullOrEmpty(loginResource) || string.IsNullOrEmpty(passwordResource)) return;
            
            password.Password = passwordResource;
            login.Text = loginResource;
        }

        private void SignUp_OnClick(object sender, RoutedEventArgs e)
        {
            if (isRemeber.IsChecked ?? false)
            {
                Properties.UserSettings.Default.UserLogin = login.Text;
                Properties.UserSettings.Default.UserPassword = password.Password;
                Properties.UserSettings.Default.Save();
            }
            else
            {
                Properties.UserSettings.Default.UserLogin = string.Empty;
                Properties.UserSettings.Default.UserPassword = string.Empty;
                Properties.UserSettings.Default.Save();
            }

            MessageBox.Show("Добро пожаловать!");
        }
    }
}