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
    /// Логика взаимодействия для pageFlightDetail.xaml
    /// </summary>
    public partial class pageFlightDetail : Page
    {
        OleDB db = new OleDB();

        public pageFlightDetail(string flightId)
        {
            InitializeComponent();
            setFlightData(flightId);
        }

        private void setFlightData(string flightId)
        {
            SQL sql = new SQL();

            OleDbDataReader data = db.Select(sql.defaultSqlTicketsList + "WHERE flight_id = " + flightId);
            while (data.Read())
            {
                // определение пунктов отправления и прибытия
                int dcx = 0, dcy = 0, acx = 0, acy = 0;
                OleDbDataReader dc = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(1));
                while (dc.Read())
                {
                    placeDepTB.Content = dc.GetValue(1);
                    dcx = Convert.ToInt32(dc.GetValue(2) + "");
                    dcy = Convert.ToInt32(dc.GetValue(3) + "");
                }
                OleDbDataReader ac = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(2));
                while (ac.Read())
                {
                    placeArrTB.Content = ac.GetValue(1);
                    acx = Convert.ToInt32(ac.GetValue(2) + "");
                    acy = Convert.ToInt32(ac.GetValue(3) + "");
                }

                // определение даты вылета и времени в пути

                flightTimeTB.Content = "Дата вылета: " + conctructDateTimeFromAccess(data.GetValue(3) + "", data.GetValue(4) + "");
                timeToTravelTB.Content = calcTravelTime(dcx, dcy, acx, acy);

                // определение информации про самолёт
                airlineTB.Content = "Авиакомпания: " + data.GetValue(5) + " мест";
                boardingATB.Content = "1-Класс: " + data.GetValue(6) + " мест";
                boardingBTB.Content = "Бизнес: " + data.GetValue(8) + " мест";
                boardingCTB.Content = "Комфорт: " + data.GetValue(10) + " мест";
                boardingDTB.Content = "Эконом: " + data.GetValue(12) + " мест";
            }
        }

        private void calcFlightPrice() {   }

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
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
