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
    /// Логика взаимодействия для pageUserBookingTickets.xaml
    /// </summary>
    public partial class pageUserBookingTickets : Page
    {
        OleDB db = new OleDB();
        SQL sql = new SQL();

        public pageUserBookingTickets(string user_id)
        {
            InitializeComponent();
            uploadBookingTickets(user_id);
        }

        public void uploadBookingTickets(string u_id)
        {
            OleDbDataReader flights = db.Select("SELECT flight_id, class FROM Booking_history WHERE user_id = " + u_id);
            while (flights.Read())
            {
                string flightId = flights.GetValue(0) + "",
                       ticketClass = flights.GetValue(1) + "",
                       ticketClassText = "Билет класса: ";

                OleDbDataReader data = db.Select(sql.defaultSqlTicketsList + "WHERE flight_id = " + flightId);
                while (data.Read())
                {
                    string depCity = "", arrCity = "";

                    OleDbDataReader dc = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(1));
                    while (dc.Read())
                    {
                        depCity = dc.GetValue(1) + "";
                    }
                    OleDbDataReader ac = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(2));
                    while (ac.Read())
                    {
                        arrCity = ac.GetValue(1) + "";
                    }


                    string flight = depCity + " - " + arrCity,
                           depTime = "Вылет: " + conctructDateTimeFromAccess(data.GetValue(3) + "", data.GetValue(4) + ""),
                           airlineName = "Авиакомпания: " + data.GetValue(5);

                    switch (ticketClass)
                    {
                        case "1":
                            ticketClassText += "1-Класс";
                            break;
                        case "2":
                            ticketClassText += "Бизнес";
                            break;
                        case "3":
                            ticketClassText += "Комфорт";
                            break;
                        case "4":
                            ticketClassText += "Эконом";
                            break;
                        default:
                            ticketClassText = "";
                            break;
                    }

                    ticketsList.Items.Add(new columnsData { flightTB = flight, depTimeTB = depTime, airlineNameTB = airlineName, boardingATB = ticketClassText });
                }
            }
        }

        private string conctructDateTimeFromAccess(string date, string time)
        {
            date = date.Substring(0, date.Length - 9);
            time = time.Substring(11);
            return date + " - " + time;
        }
    }
}
