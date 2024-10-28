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
    /// Логика взаимодействия для pageRegistration.xaml
    /// </summary>
    public partial class pageRegistration : Page
    {

        Window MW;
        OleDB db = new OleDB();

        public pageRegistration(Window mainWindow)
        {
            mainWindow.Title = "AirTicket | Регистрация";
            InitializeComponent();
            MW = mainWindow;
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTB.Text,
                   password = passwordTB.Text,
                   userName = userNameTB.Text;

            if (!String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                string result = reg(login, password, userName);

                switch (result)
                {
                    case "a":
                        MessageBox.Show("Ошибка: уже существует пользователь с таким логином", "Ошибка регистрации");
                        break;
                    case "-":
                        MessageBox.Show("Ошибка: неизвестная ошибка", "Ошибка регистрации");
                        break;

                    default:
                        MessageBox.Show("Вы успешно зарегестрированы! \nНажмите \"ok\" и войдите в аккаунт");
                        NavigationService.Navigate(new pageAuthorization(MW));
                        break;
                }
            } else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        public string reg(string login, string pass, string name)
        {
            if (!checkUniqLogin(login))
            {
                return "a";
            }
            
            db.Select("INSERT INTO Users([user_name], [login], [password], [role]) VALUES ('" + name + "', '" + login + "', '" + pass + "', 1)");

            return "";
        }


        public bool checkUniqLogin(string login)
        {
            OleDbDataReader data = db.Select("SELECT * FROM Users WHERE [login] = '" + login + "'");

            int counter = 0;

            while (data.Read())
            {
                counter++;

                if (counter > 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pageAuthorization(MW));
        }
    }
}
