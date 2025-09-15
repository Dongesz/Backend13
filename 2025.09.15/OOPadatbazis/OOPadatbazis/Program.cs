using System.Data;
using System.Data.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace OOPadatbazis
{
    public class DbConnection
    {
        public DbConnection()
        {

        }

        public string Server { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public MySqlConnection Connection { get; set; }

        private static DbConnection _instance = null;
        public static DbConnection Instance()
        {
            if (_instance == null)
                _instance = new DbConnection();
            return _instance;
        }
        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}", Server, DatabaseName, UserName, Password);
                Connection = new MySqlConnection(connstring);
                Connection.Open();
            }

            return true;
        }

        public void Close()
        {
            Connection.Close();
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                var dbCon = DbConnection.Instance();
                dbCon.Server = "localhost";
                dbCon.DatabaseName = "library";
                dbCon.UserName = "root";
                dbCon.Password = "";
                if (dbCon.IsConnect())
                {
                    Console.WriteLine("Sikeres csatlakozas!");
                }
                    dbCon.Close();
                }
        }
    }
}