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

        string u_id, u_role;

        public pageMain(string user_id, Window mainWindow)
        {
            mainWindow.Title = "AirTicket | Главная страница";
            InitializeComponent();
            MW = mainWindow;
            u_id = user_id;

            OleDbDataReader data = db.Select("SELECT user_name, role FROM Users WHERE user_id = " + user_id + "");
            while (data.Read())
            {
                userName.Content = data.GetValue(0);
                u_role = data.GetValue(1) + "";
            }
        }

        private void profileBtn_Click(object sender, RoutedEventArgs e)
        {
            var form = new ProfileWindow(u_id, MW);
            form.Show();
        }
    }
}