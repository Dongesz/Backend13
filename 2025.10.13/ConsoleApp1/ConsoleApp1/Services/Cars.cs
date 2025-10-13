using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using NotesApp.Services;

namespace ConsoleApp1.Services
{
    public class Cars : ICars
    {
        Connect conn = new Connect();
        public void AddCar(string brand, string type, string license, int date)
        {
            conn._connection.Open();
            string sql = "insert into Cars (Brand, Type, License, Date) values (@brand, @type, @license, @date);";
            
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            cmd.Parameters.AddWithValue("@brand", brand);
            cmd.Parameters.AddWithValue("@type", type);
            cmd.Parameters.AddWithValue("@license", license);
            cmd.Parameters.AddWithValue("@date", date);

            cmd.ExecuteNonQuery();

            conn._connection.Close();

        }

        public void DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public void GetAllCar()
        {
            conn._connection.Open();
            string sql = "SELECT * FROM cars";
            MySqlCommand mySqlCommand = new MySqlCommand(sql, conn._connection);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32("Id");
                string brand = reader.GetString("Brand");
                string type = reader.GetString("Type");
                string license = reader.GetString("License");
                int date = reader.GetInt32("Date");

                Console.WriteLine($"{id} {brand} {type} {license} {date}");
            }
            conn._connection.Close();

        }

        public void UpdateCar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
