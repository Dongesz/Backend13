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
using WfpApp.Services.Systems;

namespace WfpApp
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private readonly UserRepository _userRepository;

        private readonly Frame _mainframe;
        public RegPage( Frame mainframe)
        {
            InitializeComponent();
            _mainframe = mainframe;

            var db = new DatabaseConnection("Server=localhost;Database=computershop;Uid=root;Password=;SslMode=None;");
            _userRepository = new UserRepository(db);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _mainframe.Navigate(new LoginPage(_mainframe));
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                     string.IsNullOrWhiteSpace(FullNameTextBox.Text) ||
                     string.IsNullOrWhiteSpace(PasswordBox1.Password) ||
                     string.IsNullOrWhiteSpace(PasswordBox2.Password) ||
                     string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    MessageBox.Show("Kérlek tölts ki minden mezőt!");
                    return;
                }

                var result = await _userRepository.TryRegisterAsync(
                    PasswordBox1.Password,
                    PasswordBox2.Password,
                    UsernameTextBox.Text,
                    FullNameTextBox.Text,
                    EmailTextBox.Text);

                if (result)
                {
                    MessageBox.Show("Sikeres Regisztracio!");
                    _mainframe.Navigate(new AdminPage());
                }
                else MessageBox.Show("Hibas Regisztracios adatok!");
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show($"Hiba tortent: {ex.Message}");
                }

            }
        }
    }
}
