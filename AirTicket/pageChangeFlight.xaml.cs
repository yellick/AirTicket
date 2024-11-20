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
using System.Text.RegularExpressions;
using System.Reflection;

namespace AirTicket
{
    /// <summary>
    /// Логика взаимодействия для pageChangeFlight.xaml
    /// </summary>
    public partial class pageChangeFlight : Page
    {
        GeneralMethods gm = new GeneralMethods();
        OleDB db = new OleDB();
        private string flightId;
        private int selectionCounter = 0;

        public pageChangeFlight(string f_id)
        {
            InitializeComponent();
            flightId = f_id;

            setFlightData();
        }

        private void setFlightData()
        {
            List<string> values = getValues(flightId);

            string placeDep = values[0],
                   placeArr = values[1],
                   flightDate = gm.getDate(values[2]),
                   flightTime = gm.getTime(values[3]),

                   airlineId = values[13],
                   planeId = values[14];

            setComboBoxData(airlineId, placeDep, placeArr, planeId);

            
        }

        private void setComboBoxData(string curAirlineId, string curDepId, string curArrId, string curPlaneId)
        {
            int index = 0;

            OleDbDataReader cityes = db.Select("SELECT * FROM airports");
            while (cityes.Read())
            {
                string id = cityes.GetValue(0) + "",
                       name = cityes.GetValue(1) + "";

                placeDepCB.Items.Add(new CBData { Id = id, Name = name });
                placeArrCB.Items.Add(new CBData { Id = id, Name = name });

                if (id == curDepId) { placeDepCB.SelectedIndex = index; }
                if (id == curArrId) { placeArrCB.SelectedIndex = index; }

                index++;
            }
            index = 0;

            OleDbDataReader airlines = db.Select("SELECT * FROM airlines");
            while (airlines.Read())
            {
                string id = airlines.GetValue(0) + "",
                       name = airlines.GetValue(1) + "";

                airlineCB.Items.Add(new CBData { Id = id, Name = name });

                if (id == curAirlineId) { airlineCB.SelectedIndex = index; }
                index++;
            }
            index = 0;

            OleDbDataReader planes = db.Select("SELECT * FROM Planes WHERE airline_id = " + curAirlineId);
            while (planes.Read())
            {
                string planeId = planes.GetValue(0) + ". Количество мест",
                       addString = "";

                addString += "1-Класс: " + planes.GetValue(2);
                addString += ", Бизнес: " + planes.GetValue(4);
                addString += ", Комфорт: " + planes.GetValue(6);
                addString += ", Эконом: " + planes.GetValue(8);

                planeCB.Items.Add(new CBData { Id = planeId, Name = addString });

                if (planes.GetValue(0) + "" == curPlaneId) { planeCB.SelectedIndex = index; }
                index++;
            }
        }
        
        private void updatePlanes(string airlineId)
        {
            OleDbDataReader planes = db.Select("SELECT * FROM Planes WHERE airline_id = " + airlineId);
            while (planes.Read())
            {
                string planeId = planes.GetValue(0) + ". Количество мест",
                       addString = "";

                addString += "1-Класс: " + planes.GetValue(2);
                addString += ", Бизнес: " + planes.GetValue(4);
                addString += ", Комфорт: " + planes.GetValue(6);
                addString += ", Эконом: " + planes.GetValue(8);

                planeCB.Items.Add(new CBData { Id = planeId, Name = addString });
            }
        }

        private List<string> getValues(string flightId)
        {
            string sql = "SELECT " +
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
                            "Planes.boarding_d_ratio, " +
                            "Airlines.airline_id, " +
                            "Planes.plane_id " +
                          "FROM " +
                            "(Flights INNER JOIN Planes ON Flights.plane_id = Planes.plane_id) " +
                            "INNER JOIN Airlines ON Planes.airline_id = Airlines.airline_id ";

            OleDbDataReader data = db.Select(sql + "WHERE flight_id = " + flightId);

            List<string> values = new List<string>();

            while (data.Read())
            {
                int counter = 0;
                while (true)
                {
                    try
                    {
                        values.Add(data.GetValue(counter) + "");
                        counter++;
                    }
                    catch
                    {
                        break;
                    }
                }
            }

            return values;
        }

        private static bool isValidTimeFormat(string val)
        {
            // Регулярное выражение для проверки формата времени HH:mm:ss
            string pattern = @"^(0[0-9]|1[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(val);
        }

        public static bool isValidDateFormat(string val)
        {
            // Регулярное выражение для проверки формата даты DD.MM.YYYY
            string pattern = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$";
            Regex regex = new Regex(pattern);

            return regex.IsMatch(val);
        }


        private void changeFlight_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что сохранить изменения?\nВозврат данных будет невозможен",
                       "Сохранить изменения?",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                List<string> values = new List<string>();

                string placeDepId = placeDepCB.Text.Split('-')[0].Split(' ')[0],
                       placeArrId = placeArrCB.Text.Split('-')[0].Split(' ')[0],

                       flightDate = flightDateDP.Text,
                       flightTime = flightTimeTB.Text,

                       planeId = planeCB.Text.Split('.')[0];


                bool allValid = true;

                if (!isValidTimeFormat(flightTime))
                {
                    MessageBox.Show("Введите время в формате 00:00:00");
                    allValid = false;
                }
                if (!isValidDateFormat(flightDate))
                {
                    MessageBox.Show("Введите дату в формате 00.00.0000");
                    allValid = false;
                }

                if (allValid)
                {
                    string SQLchangeFlights = "UPDATE Flights SET " +
                                                "plane_id = " + planeId + ", " +
                                                "flight_date = '" + flightDate+ "', " +
                                                "place_departurete = " + placeDepId + ", " +
                                                "place_arrival = " + placeArrId + ", " +
                                                "flight_time = '" + flightTime + "' " +
                                              "WHERE flight_id = " + flightId;

                    db.Select(SQLchangeFlights);
                }
            }
        }
        
        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void airlineCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectionCounter++;
            if (selectionCounter > 1)
            {
                updatePlanes(airlineCB.Text.Split('-')[0].Split(' ')[0]);
            }
        }
    }
}
