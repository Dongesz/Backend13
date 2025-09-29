using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WfpApp.Services.Interfaces;


namespace WfpApp.Services.Systems
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConnection _db;
        public UserRepository(DatabaseConnection db)
        {
            _db = db;
        }
        // Helper for login
        public async Task<bool> TryLoginAsync(string password, string username)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("SELECT 1 FROM users WHERE Username = @username AND Password = @password LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@username", username);
            var result = await cmd.ExecuteScalarAsync();
            return result != null;
        }
        //Helper for register
        public async Task<bool> TryRegisterAsync(string password1, string password2, string username, string fullname, string email)
        {
            if(password1 == password2)
            {
                using var conn = await _db.GetOpenConnectionAsync();
                using var cmd = new MySqlCommand("INSERT INTO users (Username, FullName, Password, Email) VALUES (@username, @fullname, @password, @email)", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@fullname", fullname);
                cmd.Parameters.AddWithValue("@password", password1);
                cmd.Parameters.AddWithValue("@email", email);
                int affectedRows = await cmd.ExecuteNonQueryAsync();
                return affectedRows >0;
            }
            return false;
        }
        public async Task<ICollection<string>> GetDataAsync()
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("SELECT Username FROM users;", conn);

            var users = new List<string>();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add(reader.GetString("Username"));
            }
            return users;
        }

        public async Task<bool> UpdateDataAsync(string password1, string password2, string username, string fullname, string email)
        {

            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("UPDATE users SET Username = @username, FullName = @fullname, Password = @password, Email = @email WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@password", password1);
            cmd.Parameters.AddWithValue("@email", email);
            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }

        public async Task<bool> DeleteDataAsync(string username)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("DELETE FROM users WHERE Username = @username", conn);
            cmd.Parameters.AddWithValue("@username", username);

            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }

        public  async Task<bool> CreateDataAsync(string password1, string password2, string username, string fullname, string email)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("INSERT INTO users (Username, FullName, Password, Email) VALUES (@username, @fullname, @password, @email)", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@password", password1);
            cmd.Parameters.AddWithValue("@email", email);
            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }
    }
}
