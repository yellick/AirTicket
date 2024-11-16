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
        private string FlightId,
                       u_id;

        public pageFlightDetail(string flightId, string user_id)
        {
            InitializeComponent();
            setFlightData(flightId);
            FlightId = flightId;
            u_id = user_id;
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
                    placeDepTB.Content = "Место вылета - " + dc.GetValue(1);
                    dcx = Convert.ToInt32(dc.GetValue(2) + "");
                    dcy = Convert.ToInt32(dc.GetValue(3) + "");
                }
                OleDbDataReader ac = db.Select("SELECT * FROM Airports WHERE airport_id = " + data.GetValue(2));
                while (ac.Read())
                {
                    placeArrTB.Content = "Место прибытия - " + ac.GetValue(1);
                    acx = Convert.ToInt32(ac.GetValue(2) + "");
                    acy = Convert.ToInt32(ac.GetValue(3) + "");
                }

                // определение даты вылета и времени в пути
                flightTimeTB.Content = "Дата вылета: " + conctructDateTimeFromAccess(data.GetValue(3) + "", data.GetValue(4) + "");

                string timeTravel = calcTravelTime(dcx, dcy, acx, acy);
                timeToTravelTB.Content = "Примерное время в пути: " + timeTravel;


                int sitsCount = Convert.ToInt32(data.GetValue(6)) +
                                Convert.ToInt32(data.GetValue(8)) + 
                                Convert.ToInt32(data.GetValue(10)) + 
                                Convert.ToInt32(data.GetValue(12));


                // определение информации про самолёт
                double[] coefficients = new double[4];

                // Присваивание значений элементам массива
                coefficients[0] = double.Parse(data.GetValue(7) + "");
                coefficients[1] = double.Parse(data.GetValue(9) + "");
                coefficients[2] = double.Parse(data.GetValue(11) + "");
                coefficients[3] = double.Parse(data.GetValue(13) + "");

                double[] prices = calcPrice(timeTravel, coefficients, sitsCount);

                airlineTB.Content = "Авиакомпания: " + data.GetValue(5);
                boardingATB.Content += data.GetValue(6) + " мест";
                costATB.Content = "Стоимость - " + Math.Round(prices[0]) + " руб.";

                boardingBTB.Content += data.GetValue(8) + " мест";
                costBTB.Content = "Стоимость - " + Math.Round(prices[1]) + " руб.";

                boardingCTB.Content += data.GetValue(10) + " мест";
                costCTB.Content = "Стоимость - " + Math.Round(prices[2]) + " руб.";

                boardingDTB.Content += data.GetValue(12) + " мест";
                costDTB.Content = "Стоимость - " + Math.Round(prices[3]) + " руб.";

            }
        }

        private double[] calcPrice (string tt, double[] ratio, int sitsCount)
        {
            const int MinutePlaneFlightCost = 50000; //в рублях

            string[] ttArr = tt.Split(':');
            int minutes = (Convert.ToInt32(ttArr[0]) * 60) + Convert.ToInt32(ttArr[1]);

            double[] prices = new double[4];

            for (int i = 0; i < ratio.Length; i++)
            {
                double flightPrice = minutes * MinutePlaneFlightCost * 1.05,
                       ratioDouble = ratio[i];

                prices[i] = (flightPrice / sitsCount) * ratioDouble;
            }

            return prices;
        }

        private string calcTravelTime(int dcx, int dcy, int acx, int acy)
        {
            decimal minutes,
                    hours = 0,
                    distanse = Convert.ToDecimal(Math.Sqrt(Math.Pow(acx - dcx, 2) + Math.Pow(acy - dcy, 2)) * 10);

            hours = distanse / 700;
            minutes = 60 * (hours % 1);

            string tt = Math.Truncate(hours) + ":" + Math.Truncate(minutes);
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

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            OleDbDataReader flights =  db.Select("SELECT bh_id FROM Booking_history WHERE flight_id = " + FlightId + " AND user_id = " + u_id);
            while (flights.Read())
            {
                MessageBox.Show("Вы уже забронировали билет на этот рейс");
                return;
            }

            Window bookWin = new BookTicketWindow(u_id, FlightId);
            bookWin.Show();
        }
    }
}
