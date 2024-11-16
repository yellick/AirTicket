using System.Data.OleDb;

namespace AirTicket
{
    class OleDB
    {
        public string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=DB.mdb";
        //public string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\edu.local\public\studenthomes\22201003\Desktop\AirTicket\DB.mdb";

        public OleDbDataReader Select(string selectSQL)
        {
            OleDbConnection connect = new OleDbConnection(connection);
            connect.Open();

            OleDbCommand cmd = new OleDbCommand(selectSQL, connect);
            OleDbDataReader reader = cmd.ExecuteReader();

            return reader;
        }
    }
}
