using de14;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
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

namespace AirTicket
{
    /// <summary>
    /// Логика взаимодействия для pageAuthorization.xaml
    /// </summary>
    public partial class pageAuthorization : Page
    {

        OleDB db = new OleDB();
        public pageAuthorization()
        {
            InitializeComponent();
        }

        private void authBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTB.Text,
                   password = passwordTB.Text;

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                string result = auth(login, password);

                switch (result)
                {
                    case "a":
                        MessageBox.Show("Ошибка: неправильный логин или пароль", "Ошибка входа");
                        break;
                    case "b":
                        MessageBox.Show("Ошибка: несколько пользователей с одинаковыми логином и паролем", "Ошибка входа");
                        break;
                    case "-":
                        MessageBox.Show("Ошибка: неизвестная ошибка", "Ошибка входа");
                        break;

                    default:
                        MessageBox.Show("Вы успешно авторизованы!");
                        break;
                }
            }
        }

        public string auth(string login, string pass)
        {
            OleDbDataReader data = db.Select("SELECT * FROM Users WHERE [login] = '" + login + "' AND [password] = '" + pass + "'");


            int counter = 0;
            string user_id = "";

            while (data.Read())
            {
                counter++;
                user_id = data.GetValue(0) + "";

                if (counter > 1)
                {
                    break;
                }
            }

            if (counter == 1)
            {
                return user_id;
            }
            else if (counter == 0)
            {
                return "a";
            }
            else if (counter > 1)
            {
                return "b";
            }
            else
            {
                return "-";
            }
        }
    }
}
