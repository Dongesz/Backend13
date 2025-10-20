using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public class Connect
    {
        public MySqlConnection _connection;

        public Connect()
        {
            string connString = "server=localhost;database=auto;uid=root;pwd=;";
            _connection = new MySqlConnection(connString);
        }
    }
}
