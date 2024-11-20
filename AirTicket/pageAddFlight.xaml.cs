using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для pageAddFlight.xaml
    /// </summary>
    public partial class pageAddFlight : Page
    {
        OleDB db = new OleDB();
        private int selectionCounter = 0;

        public pageAddFlight()
        {
            InitializeComponent();
            setDataToCb();
        }

        private void setDataToCb()
        {
            OleDbDataReader cityesDB = db.Select("SELECT * FROM Airlines");

            OleDbDataReader cityes = db.Select("SELECT * FROM airports");
            while (cityes.Read())
            {
                string id = cityes.GetValue(0) + "",
                       name = cityes.GetValue(1) + "";

                placeDepCB.Items.Add(new CBData { Id = id, Name = name });
                placeArrCB.Items.Add(new CBData { Id = id, Name = name });
            }

            OleDbDataReader airlines = db.Select("SELECT * FROM airlines");
            while (airlines.Read())
            {
                string id = airlines.GetValue(0) + "",
                       name = airlines.GetValue(1) + "";

                airlineCB.Items.Add(new CBData { Id = id, Name = name });
            }
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

        private void addFlight_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите добавить новый рейс?\nНажмите \"Да\" чтобы продолжить",
                       "Добавить рейс?",
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
                    MessageBox.Show("INSERT INTO Flights (plane_id, flight_date, place_departurete, place_arrival, flight_time) " +
                                $"VALUES ( {planeId}, '{flightDate}', {placeDepId}, {placeArrId}, '{flightTime}')");
                    
                    db.Select("INSERT INTO Flights (plane_id, flight_date, place_departurete, place_arrival, flight_time) " +
                                $"VALUES ( {planeId}, '{flightDate}', {placeDepId}, {placeArrId}, '{flightTime}')");
                    
                }
            }
        }

        private void searchPlanes_Click(object sender, RoutedEventArgs e)
        {
            string airlineId = airlineCB.Text.Split('-')[0].Split(' ')[0];
            if(String.IsNullOrEmpty(airlineId))
            {
                MessageBox.Show("Выберите авиакомпанию");
                return;
            }

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

            MessageBox.Show("Самолёты найдены");
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
