using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UserRepository _userRepository;
        public MainWindow()
        {
            InitializeComponent();
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
                    var nav = new NavigationWindow();
                    nav.Source = new Uri("RegPage.xaml", UriKind.Relative);
                    nav.Show();
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
       
        
    }
}