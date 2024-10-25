using System.Data.OleDb;

namespace de14
{
    class OleDB
    {
        // дом
        //public string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\other\projects\WPF\AirTicket\DB.mdb";
        // колледж
        public string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\\edu.local\public\studenthomes\22201003\Desktop\AirTicket\DB.mdb";

        public OleDbDataReader Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            OleDbConnection connect = new OleDbConnection(connection); // подключаемся к базе данных
            connect.Open(); // открываем базу данных

            OleDbCommand cmd = new OleDbCommand(selectSQL, connect); // создаём запрос
            OleDbDataReader reader = cmd.ExecuteReader(); // получаем данные

            return reader; // возвращаем
        }
    }
}
