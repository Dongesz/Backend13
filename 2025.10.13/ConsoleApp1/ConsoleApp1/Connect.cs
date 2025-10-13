using MySql.Data.MySqlClient;

namespace NotesApp.Services
{
    public class Connect
    {
        public MySqlConnection _connection;

        public Connect()
        {
            string connString = "server=localhost;database=notesdb;uid=root;pwd=;";
            _connection = new MySqlConnection(connString);
        }
    }
}
