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
            string placeDep,
                   placeArr,
                   flightTime,
                   timeToTravel,

                   airline,

                   boardingA,
                   boardingACost,

                   boardingB,
                   boardingBCost,

                   boardingC,
                   boardingCCost,

                   boardingD,
                   boardingDCost;

            OleDbDataReader data = db.Select("");
        }

        private void goBackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
