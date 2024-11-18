﻿using System;
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
    /// Логика взаимодействия для pageChangeFlight.xaml
    /// </summary>
    public partial class pageChangeFlight : Page
    {
        GeneralMethods gm = new GeneralMethods();
        OleDB db = new OleDB();
        private string flightId;

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
                   airlineName = values[4],

                   planeId = values[14],

                   planeBoardingA = values[5],
                   planeBoardingARatio = values[6],

                   planeBoardingB = values[7],
                   planeBoardingBRatio = values[8],

                   planeBoardingC = values[9],
                   planeBoardingCRatio = values[10],

                   planeBoardingD = values[11],
                   planeBoardingDRatio = values[12];

            setComboBoxData(airlineId, placeDep, placeArr);

            airlineIdTB.Content = airlineId;
            planeIdTB.Content = planeId;

            flightDateDP.Text = flightDate;
            flightTimeTB.Text = flightTime;

            boardingATB.Text = planeBoardingA;
            ratioATB.Text = planeBoardingARatio;

            boardingBTB.Text = planeBoardingB;
            ratioBTB.Text = planeBoardingBRatio;

            boardingCTB.Text = planeBoardingC;
            ratioCTB.Text = planeBoardingCRatio;

            boardingDTB.Text = planeBoardingD;
            ratioDTB.Text = planeBoardingDRatio;
        }

        private void setComboBoxData(string curAirlineId, string curDepId, string curArrId)
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

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void changeFlight_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены что сохранить изменения?\nВозврат данных будет невозможен",
                       "Сохранить изменения?",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                MessageBox.Show("pass");
            }
        }
    }
}