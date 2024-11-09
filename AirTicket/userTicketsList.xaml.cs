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
    /// Логика взаимодействия для userTicketsList.xaml
    /// </summary>
    public partial class userTicketsList : Page
    {
        OleDB db = new OleDB();

        public userTicketsList()
        {
            InitializeComponent();
            uploadDataOnList();
        }

        private void uploadDataOnList()
        {
            OleDbDataReader data = db.Select("SELECT " +
                                                "Flights.flight_id, " +
                                                "Flights.place_departurete, " +
                                                "Flights.place_arrival, " +
                                                "Flights.flight_date, " +
                                                "Flights.flight_time, " +
                                                "Airlines.airline_name, " +
                                                "Planes.boarding_a, " +
                                                "Planes.boarding_a_ratio, " +
                                                "Planes.boarding_b, " +
                                                "Planes.boarding_b_ratio, " +
                                                "Planes.boarding_c, " +
                                                "Planes.boarding_c_ratio, " +
                                                "Planes.boarding_d, " +
                                                "Planes.boarding_d_ratio " +
                                             "FROM " +
                                                "(Flights INNER JOIN Planes ON Flights.plane_id = Planes.plane_id) " +
                                                "INNER JOIN Airlines ON Planes.airline_id = Airlines.airline_id");

            while (data.Read())
            {
                // 0 - Flights.flight_id
                // 1 - Flights.place_departurete
                // 2 - Flights.place_arrival
                // 3 - Flights.flight_date
                // 4 - Flights.flight_time
                // 5 - Airlines.airline_name
                // 6 - Planes.boarding_a
                // 7 - Planes.boarding_a_ratio
                // 8 - Planes.boarding_b
                // 9 - Planes.boarding_b_ratio
                // 10 - Planes.boarding_c
                // 11 - Planes.boarding_c_ratio
                // 12 - Planes.boarding_d
                // 13 - Planes.boarding_d_ratio


                string depCity = "", arrCity = "";
                int dcx = 0, dcy = 0, acx = 0, acy = 0;

                OleDbDataReader dc = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(1));
                while (dc.Read())
                {
                    depCity = dc.GetValue(1) + "";
                    dcx = Convert.ToInt32(dc.GetValue(2) + "");
                    dcy = Convert.ToInt32(dc.GetValue(3) + "");
                }
                OleDbDataReader ac = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(2));
                while (ac.Read())
                {
                    arrCity = ac.GetValue(1) + "";
                    acx = Convert.ToInt32(ac.GetValue(2) + "");
                    acy = Convert.ToInt32(ac.GetValue(3) + "");
                }


                string flight = depCity + " - " + arrCity,
                       depTime = "Вылет: " + conctructDateTimeFromAccess(data.GetValue(3)+"", data.GetValue(4)+""),
                       flightTime = "Примерное время в пути - " + calcTravelTime(dcx, dcy, acx, acy),
                       airlineName = "Авиакомпания: " + data.GetValue(5),
                       boardingA = "1-Класс: " + data.GetValue(6),
                       boardingB = "Бизнес: " + data.GetValue(8),
                       boardingC = "Комфорт: " + data.GetValue(10),
                       boardingD = "Эконом: " + data.GetValue(12);


                ticketsList.Items.Add(new columnsData { flightTB = flight, depTimeTB = depTime, flightTimeTB = flightTime, airlineNameTB = airlineName, boardingATB = boardingA, boardingBTB = boardingB, boardingCTB = boardingC, boardingDTB = boardingD });

            }
        }

        private string calcTravelTime(int dcx, int dcy, int acx, int acy)
        {
            decimal minutes,
                    hours = 0,
                    distanse = Convert.ToDecimal(Math.Sqrt(Math.Pow(acx - dcx, 2) + Math.Pow(acy - dcy, 2)) * 10);

            hours = distanse / 700;
            minutes = 60 * (hours % 1);

            string tt = Math.Truncate(hours) + " час, " + Math.Truncate(minutes) + " минут";
            return tt;
        }

        private string conctructDateTimeFromAccess(string date, string time)
        {
            date = date.Substring(0, date.Length - 9);
            time = time.Substring(11);
            return date + " - " + time;
        }
    }

    public class columnsData
    {
        public string flightTB { get; set; }
        public string depTimeTB { get; set; }
        public string flightTimeTB { get; set; }
        public string airlineNameTB { get; set; }
        public string boardingATB { get; set; }
        public string boardingBTB { get; set; }
        public string boardingCTB { get; set; }
        public string boardingDTB { get; set; }
    }
}
