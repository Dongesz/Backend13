using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WfpApp.Scripts;


namespace WfpApp.Scripts
{
    public class UserRepository
    {
        private readonly DatabaseConnection _db;
        public UserRepository(DatabaseConnection db)
        {
            _db = db;
        }
        // Test Method
        public async Task<string> GetUsernameByIdAsync(int id)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("SELECT UserName FROM users WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            var result = await cmd.ExecuteScalarAsync();
            return result?.ToString() ?? string.Empty;
        }
        public async Task<bool> TryLoginAsync(string password, string username)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("SELECT 1 FROM users WHERE Username = @username AND Password = @password LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@username", username);
            var result = await cmd.ExecuteScalarAsync();
            return result != null;
        }

    }
}
