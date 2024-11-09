using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.OleDb;
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
        OleDB db = new OleDB();

        Window MW;
        string u_id;
        Label userNameLable;

        public ProfileWindow(string user_id, Window mainWindow, Label userNameL)
        {
            mainWindow.IsEnabled = false;
            InitializeComponent();
            MW = mainWindow;
            u_id = user_id;
            userNameLable = userNameL;

            setUserDataToTB();
        }


        private void setUserDataToTB()
        {
            OleDbDataReader data = db.Select("SELECT user_name, login FROM Users WHERE user_id = " + u_id);

            while (data.Read())
            {
                userNameTB.Text = data.GetValue(0) + "";
                userLoginTB.Text = data.GetValue(1) + "";
                
            }
        }

        private bool checkPassword(string password)
        {
            OleDbDataReader userPassword = db.Select("SELECT password FROM Users WHERE user_id = " + u_id);
            while (userPassword.Read())
            {
                if (password == userPassword.GetValue(0) + "")
                {
                    return true;
                }
            }

            return false;
        }

        private void closeWindow()
        {
            MW.IsEnabled = true;
            this.Close();
        }

        private void saveNameAndLogin_Click(object sender, RoutedEventArgs e)
        {
            string name = userNameTB.Text,
                   login = userLoginTB.Text;


            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(login))
            {
                db.Select("UPDATE Users " +
                          "SET " +
                            "user_name = '" + name + "', " +
                            "login = '" + login + "' " +
                          "WHERE user_id = " + u_id);
                userNameLable.Content = name;
                MessageBox.Show("Данные сохранены!");
                closeWindow();
            } else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void changePassword_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordTB.Text,
                   newPassword = newPasswordTB.Text;

            if (checkPassword(password))
            {
                db.Select("UPDATE Users SET [password] = '" + newPassword + "' WHERE user_id = " + u_id);
                MessageBox.Show("Пароль изменён");
                closeWindow();
            } 
            else
            {
                MessageBox.Show("Неверный пароль!");
            }
        }

        private void closeWnBtn_Click(object sender, RoutedEventArgs e)
        {
            closeWindow();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MW.IsEnabled = true;
        }
    }
}
