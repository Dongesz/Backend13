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

namespace WfpApp
{
    /// <summary>
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        private readonly Frame _mainframe;
        public RegPage( Frame mainframe)
        {
            InitializeComponent();
            _mainframe = mainframe;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _mainframe.Navigate(new LoginPage(_mainframe));
        }
    }
}
