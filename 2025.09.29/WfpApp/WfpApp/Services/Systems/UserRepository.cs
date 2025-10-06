using System;
using System.Collections.Generic;
using System.Data;
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

        public string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public string ComputeHmacSha256(string password, string salt)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt));
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        // --- LOGIN ---
        public async Task<bool> TryLoginAsync(string password, string username)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand(
                "SELECT Password, Salt FROM users WHERE Username=@username LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                string storedHash = reader.GetString("Password");
                string storedSalt = reader.GetString("Salt");
                string computedHash = ComputeHmacSha256(password, storedSalt);

                return storedHash == computedHash;
            }
            return false;
        }

        // --- REGISTER / CREATE ---
        public async Task<bool> TryRegisterAsync(string password1, string password2, string username, string fullname, string email)
        {
            if (password1 != password2) return false;

            string salt = GenerateSalt();
            string hashedPassword = ComputeHmacSha256(password1, salt);

            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand(
                "INSERT INTO users (Username, FullName, Password, Salt, Email) VALUES (@username, @fullname, @password, @salt, @email)", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.Parameters.AddWithValue("@email", email);

            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }

        public async Task<bool> CreateDataAsync(string password1, string password2, string username, string fullname, string email)
        {
            // ugyanaz mint TryRegisterAsync
            return await TryRegisterAsync(password1, password2, username, fullname, email);
        }

        // --- READ ALL ---
        public async Task<ICollection<string>> GetDataAsync()
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("SELECT Id, Username, FullName, Email, Password FROM users;", conn);

            var users = new List<string>();
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add($"{reader.GetInt32("Id")}|{reader.GetString("Username")}|{reader.GetString("FullName")}|{reader.GetString("Email")}|{reader.GetString("Password")}");
            }
            return users;
        }

        // --- READ BY ID ---
        public async Task<string> GetUserByIdAsync(int id)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand(
                "SELECT Id, Username, FullName, Email, Password FROM users WHERE Id=@id LIMIT 1;", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return $"{reader.GetInt32("Id")}|{reader.GetString("Username")}|{reader.GetString("FullName")}|{reader.GetString("Email")}|{reader.GetString("Password")}";
            }
            return null;
        }

        // --- UPDATE ---
        public async Task<bool> UpdateDataAsync(string password1, string password2, string username, string fullname, string email, int id)
        {
            string salt = GenerateSalt();
            string hashedPassword = ComputeHmacSha256(password1, salt);

            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand(
                "UPDATE users SET Username=@username, FullName=@fullname, Password=@password, Salt=@salt, Email=@email WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@salt", salt);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@id", id);

            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }

        // --- DELETE ---
        public async Task<bool> DeleteDataAsync(int id)
        {
            using var conn = await _db.GetOpenConnectionAsync();
            using var cmd = new MySqlCommand("DELETE FROM users WHERE Id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            int affectedRows = await cmd.ExecuteNonQueryAsync();
            return affectedRows > 0;
        }
    }
}
