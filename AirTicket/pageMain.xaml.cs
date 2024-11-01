using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.OleDb;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirTicket
{
    /// <summary>
    /// Логика взаимодействия для pageMain.xaml
    /// </summary>
    public partial class pageMain : Page
    {
        Window MW;
        OleDB db = new OleDB();

        string u_id;

        public pageMain(string user_id, Window mainWindow)
        {
            mainWindow.Title = "AirTicket | Главная страница";
            InitializeComponent();
            MW = mainWindow;
            u_id = user_id;

            string u_role = "";

            OleDbDataReader data = db.Select("SELECT user_name, role FROM Users WHERE user_id = " + user_id);
            while (data.Read())
            {
                userName.Content = data.GetValue(0);
                u_role = data.GetValue(1) + "";
            }

            switch (u_role)
            {
                case "1":
                    workSpace.Content = new WSUser();
                    break;

                case "2":
                    break;

                case "3":
                    break;

                default:

                    break;
            }
        }

        private void logOutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите выйти?",
                       "Выйти из аккаунта",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                NavigationService.Navigate(new pageAuthorization(MW));
            }
        }

        private void profileBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProfileWindow(u_id, MW, userName);
            form.Show();
        }
    }
}