using System.Data.OleDb;

namespace de14
{
    class OleDB
    {
        public string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\other\projects\WPF\AirTicket\DB.mdb";

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
