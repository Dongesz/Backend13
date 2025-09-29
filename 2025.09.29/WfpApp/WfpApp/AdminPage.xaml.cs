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
        public AdminPage()
        {
            InitializeComponent();
            var db = new DatabaseConnection("Server=localhost;Database=computershop;Uid=root;Password=;SslMode=None;");
            _userRepository = new UserRepository(db);
        }

        private void UsersListBox_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }
        private async void LoadUsers()
        {
            var users = await _userRepository.GetDataAsync();
            UsersListBox.ItemsSource = users;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (UsersListBox.SelectedItem is string selectedUsername)
            {
                bool success = await _userRepository.DeleteDataAsync(selectedUsername);
                if (success)
                {
                    // UI frissítése
                    (UsersListBox.ItemsSource as IList<string>).Remove(selectedUsername);
                    UsersListBox.Items.Clear();
                    LoadUsers();
                }
            }

        }
    }
}
