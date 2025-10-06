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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private readonly UserRepository _userRepository;
        private readonly Frame? _mainframe;

        public AdminPage(Frame? mainframe = null)
        {
            InitializeComponent();
            var db = new DatabaseConnection("Server=localhost;Database=computershop;Uid=root;Password=;SslMode=None;");
            _userRepository = new UserRepository(db);
            _mainframe = mainframe;
        }

        // helper a listbox feltoltesere
        private void UsersListBox_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }
        // helper az id kivalasztasara
        private bool TryParseSelectedId(out int id, out string username)
        {
            id = -1; username = null;
            if (UsersListBox.SelectedItem is string s)
            {
                var parts = s.Split('|');
                if (parts.Length >= 2 && int.TryParse(parts[0], out id))
                {
                    username = parts[1];
                    return true;
                }
            }
            return false;
        }
        // Read - OnLoad
        private async void LoadUsers()
        {
            var users = await _userRepository.GetDataAsync();
            Application.Current.Dispatcher.Invoke(() => //note tanarurnak: A dispatcher azert kell ide mivel a wpf ben minden ui element csak azon a szalon tud modosulni amin letre jott, a ui threaden. ha viszont az await utan visszater a kod nem garantalt hogy ugyanerre a threadre ter vissza, ezzel a dispatcherrel vissza kenyszeritjuk a ui threadre, igy elvegezhetjuk a modositst.
            {
                UsersListBox.ItemsSource = users;
            });
        }

        // Update
        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox1.Password != "" && PasswordBox2.Password != "" && UsernameTextBox.Text != "" && FullNameTextBox.Text != "")
            {
                if (PasswordBox1.Password == PasswordBox2.Password)
                {
                    if (TryParseSelectedId(out int id, out string username))
                    {
                        bool success = await _userRepository.UpdateDataAsync(
                            PasswordBox1.Password,
                            PasswordBox2.Password,
                            UsernameTextBox.Text,
                            FullNameTextBox.Text,
                            EmailTextBox.Text,
                            id);
                        if (success) await Task.Run(() => LoadUsers());
                    }
                }
                else MessageBox.Show("Azonos jelszó megadasa kötelező!");

            }
            else MessageBox.Show("A mezők kitöltése kötelező!");


        }
        // Create
        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox1.Password != "" && PasswordBox2.Password != "" && UsernameTextBox.Text != "" && FullNameTextBox.Text != "")
            {
                if (PasswordBox1.Password == PasswordBox2.Password)
                {
                    bool success = await _userRepository.CreateDataAsync(
                       PasswordBox1.Password,
                       PasswordBox2.Password,
                       UsernameTextBox.Text,
                       FullNameTextBox.Text,
                       EmailTextBox.Text);
                    if (success) LoadUsers();
                }
                else
                    MessageBox.Show("Azonos jelszó megadasa kötelező!");
            }
            else
                MessageBox.Show("A mezők kitöltése kötelező!");

        }
        // Delete
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TryParseSelectedId(out int id, out string username))
            {
                bool success = await _userRepository.DeleteDataAsync(id);
                if (success) LoadUsers();
            }
        }
        // Read - OnSelect
        private async void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!TryParseSelectedId(out int id, out string username))
                return;

            var user = await _userRepository.GetUserByIdAsync(id);
            if (string.IsNullOrEmpty(user))
                return;

            var fields = user.Split('|');
            if (fields.Length >= 5)
            {
                UsernameTextBox.Text = fields[1];
                FullNameTextBox.Text = fields[2];
                EmailTextBox.Text = fields[3];
                PasswordBox1.Password = fields[4];
                PasswordBox2.Password = fields[4];
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
                return;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Text = "";
            FullNameTextBox.Text = "";
            EmailTextBox.Text = "";
            PasswordBox1.Password = "";
            PasswordBox2.Password = "";
            UsersListBox.SelectedItem = null;

        }
    }
}
