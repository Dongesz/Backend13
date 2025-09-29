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
using WfpApp.Scripts;

namespace WfpApp
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly UserRepository _userRepository;
        private readonly Frame _mainFrame; 


        public LoginPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;

            var db = new DatabaseConnection("Server=localhost;Database=computershop;Uid=root;Password=;SslMode=None;");
            _userRepository = new UserRepository(db);
        }

        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var result = await _userRepository.TryLoginAsync(PasswordBox.Password, UsernameTextBox.Text);
                if (result)
                {
                    _mainFrame.Navigate(new AdminPage());
                }
                else MessageBox.Show("Hibas bejelentkezesi adatok!");
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show($"Hiba tortent: {ex.Message}");
                }

            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new RegPage(_mainFrame));
        }
    }
}
