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
    /// Логика взаимодействия для WSManager.xaml
    /// </summary>
    public partial class WSManager : Page
    {
        OleDB db = new OleDB();
        SQL sql = new SQL();
        GeneralMethods gm = new GeneralMethods();
        Window MW;

        public WSManager(Window mainWindow)
        {
            InitializeComponent();
            MW = mainWindow;


            uploadDataOnList(sql.defaultSqlTicketsList);
            setComboBox(sql.getCityesData);
        }

        private void setComboBox(string sqlCity)
        {
            OleDbDataReader cityes = db.Select(sqlCity);
            while (cityes.Read())
            {
                string id = cityes.GetValue(0) + "",
                       name = cityes.GetValue(1) + "";

                placeDepCB.Items.Add(new CBData { Id = id, Name = name });
                placeArrCB.Items.Add(new CBData { Id = id, Name = name });
            }
        }

        private void uploadDataOnList(string sql)
        {
            ticketsList.Items.Clear();

            OleDbDataReader data = db.Select(sql);

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


                string flightId = data.GetValue(0) + "",
                       flight = depCity + " - " + arrCity,
                       depTime = "Вылет: " + gm.getDate(data.GetValue(3) + "") + " - " + gm.getDate(data.GetValue(4) + ""),
                       flightTime = "Примерное время в пути - " + gm.calcTravelTime(dcx, dcy, acx, acy),
                       airlineName = "Авиакомпания: " + data.GetValue(5),
                       boardingA = "1-Класс: " + data.GetValue(6),
                       boardingB = "Бизнес: " + data.GetValue(8),
                       boardingC = "Комфорт: " + data.GetValue(10),
                       boardingD = "Эконом: " + data.GetValue(12);


                ticketsList.Items.Add(new columnsData { flightID = flightId, flightTB = flight, depTimeTB = depTime, flightTimeTB = flightTime, airlineNameTB = airlineName, boardingATB = boardingA, boardingBTB = boardingB, boardingCTB = boardingC, boardingDTB = boardingD });

            }
        }
        

        private void filteringTickets_Click(object sender, RoutedEventArgs e)
        {
            string placeDep = placeDepCB.Text,
                   placeArr = placeArrCB.Text,
                   flightDate = dateDP.Text.Replace('.', '-'),
                   additionString = "";

            bool addWhere = false;

            int counter = 0;

            if (!String.IsNullOrEmpty(placeDep) && !String.IsNullOrEmpty(placeArr) && !String.IsNullOrEmpty(flightDate)) { }

            if (!String.IsNullOrEmpty(placeDep))
            {
                placeDep = " place_departurete = " + placeDep.Split('-')[0].Split(' ')[0];
                addWhere = true;
                counter++;
            }
            else { placeDep = ""; }

            if (!String.IsNullOrEmpty(placeArr))
            {
                placeArr = " place_arrival = " + placeArr.Split('-')[0].Split(' ')[0];
                addWhere = true;
                counter++;
            }
            else { placeArr = ""; }

            if (!String.IsNullOrEmpty(flightDate))
            {
                flightDate = " flight_date = #" + flightDate + "#";
                addWhere = true;
                counter++;
            }
            else { flightDate = ""; }

            if (addWhere)
            {
                additionString += "WHERE" + placeDep;
                if (counter > 1) { additionString += " AND"; }
                additionString += placeArr;
                if (counter > 2) { additionString += " AND"; }
                additionString += flightDate;
            }

            uploadDataOnList(sql.defaultSqlTicketsList + additionString);
        }

        private void clearForm_Click(object sender, RoutedEventArgs e)
        {
            placeDepCB.SelectedIndex = -1;
            placeArrCB.SelectedIndex = -1;
            dateDP.Text = "";
            ticketsList.SelectedItem = null;
        }

        private void ticketsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = ticketsList.SelectedItem as columnsData;
            if (selectedItem != null)
            {
                string flightId = selectedItem.flightID;
                NavigationService.Navigate(new pageChangeFlight(flightId));
            }
        }
    }
}
