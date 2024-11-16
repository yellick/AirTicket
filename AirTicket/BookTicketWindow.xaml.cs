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
    /// Логика взаимодействия для BookTicketWindow.xaml
    /// </summary>
    public partial class BookTicketWindow : Window
    {
        OleDB db = new OleDB();

        string u_id,
               f_id;
        
        public BookTicketWindow(string user_id, string flight_id)
        {
            InitializeComponent();

            u_id = user_id;
            f_id = flight_id;
        }
        
        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedVal = selectClass.Text,
                   ticketClass = selectClass.Text.Split('-')[0].Split(' ')[0];
            
            if (String.IsNullOrEmpty(selectedVal))
            {
                MessageBox.Show("Выберите класс билета");
                return;
            }

            db.Select("INSERT INTO Booking_history([user_id], [flight_id], [class]) VALUES (" + u_id + ", " + f_id + ", " + ticketClass + ")");
            MessageBox.Show("Вы успешно забронировали билет класса - " + selectedVal);
            this.Close();
        }
    }
}
