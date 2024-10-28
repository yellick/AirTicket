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
using System.Windows.Shapes;

namespace AirTicket
{
    /// <summary>
    /// Логика взаимодействия для ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        Window MW;
        string u_id;
        public ProfileWindow(string user_id, Window mainWindow)
        {
            mainWindow.IsEnabled = false;
            InitializeComponent();
            MW = mainWindow;
            u_id = user_id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MW.IsEnabled = true;
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MW.IsEnabled = true;
        }
    }
}
