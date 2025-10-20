using System.Security.Cryptography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        Connect conn = new Connect();
        [HttpGet("GetAllData")]
        public List<carDto> GetAllData()
        {
            conn._connection.Open();
            List<carDto> cars = new List<carDto>();
            string sql = "SELECT * FROM `cars`";
            using (var cmd = new MySqlCommand(sql, conn._connection))
            {
                cmd.CommandText = sql;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var car = new carDto
                    {
                        Id = reader.GetInt32("Id"),
                        Brand = reader.GetString("Brand"),
                        Type = reader.GetString("Type"),
                        License = reader.GetString("License"),
                        Date = reader.GetInt32("Date")
                    };
                    cars.Add(car);
                }
            }
                return cars;
        }

        [HttpGet("GetById")]
        public object GetDataById(int id)
        {
            conn._connection.Open();
            string sql = "SELECT * from Cars WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();
            var car = new carDto { };
            while (dr.Read())
            {
                car = new carDto
                {
                    Id = dr.GetInt32("Id"),
                    Brand = dr.GetString("Brand"),
                    Type = dr.GetString("Type"),
                    License = dr.GetString("License"),
                    Date = dr.GetInt32("Date")
                };
            }
           

            
            conn._connection.Close();
            return new { result = car };
        }

        [HttpPost("AddNew")]
        public object AddNew(carDto carDto)
        {
            conn._connection.Open();

            string sql = "INSERT INTO `cars`(`Brand`, `Type`, `License`, `Date`) VALUES (@brand, @type, @license, @date)";

            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            cmd.Parameters.AddWithValue("@brand", carDto.Brand);
            cmd.Parameters.AddWithValue("@type", carDto.Type);
            cmd.Parameters.AddWithValue("@license", carDto.License);
            cmd.Parameters.AddWithValue("@date", carDto.Date);
            cmd.ExecuteNonQuery();
            conn._connection.Close();
            return new { result = carDto };
        }

        [HttpDelete("DeleteById")]
        public object DeleteById(int id)
        {
            conn._connection.Open();

            string sql = "DELETE FROM `cars` WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn._connection.Close();
            return new { message = "kys" };
        }

        [HttpPut("UpdateById")]
        public object UpdateById(int id, carDto cardto)
        {
            conn._connection.Open();

            string sql = "UPDATE `cars` SET `Brand`= @brand,`Type`= @type,`License`= @license,`Date`=@date WHERE Id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@brand", cardto.Brand);
            cmd.Parameters.AddWithValue("@type", cardto.Type);
            cmd.Parameters.AddWithValue("@license", cardto.License);
            cmd.Parameters.AddWithValue("@date", cardto.Date);

            cmd.ExecuteNonQuery();

            conn._connection.Close();

            return new { message = "GG" };
        }

        [HttpGet("GetRecordCount")]
        public object GetRecordCount()
        {
            conn._connection.Open();
            int RecordCount = 0;
            string sql = "SELECT * FROM `cars`";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            while(dr.Read())
            {
                RecordCount++;
            }

            conn._connection.Close();
            return new { message = RecordCount };

        }

        [HttpGet("GetBrandCount")]
        public object GetBrandCount()
        {
            conn._connection.Open();
            List<object> res = new List<object>();
            string sql = "SELECT Brand, Count(*) AS Count FROM `cars` Group by Brand";

            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            MySqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                res.Add(new
                {
                    Brand = rd["Brand"].ToString(),
                    Count = Convert.ToInt32(rd["Count"])
                });
            }
            rd.Close();
            conn._connection.Close();
            return Ok(res);
        }

        [HttpGet("GetAfter2020")]
        public object GetAfter2020()
        {
            conn._connection.Open();
            List<object> res = new List<object>();
            string sql = "SELECT * FROM `cars` WHERE DATE > 2020";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
           MySqlDataReader dr =  cmd.ExecuteReader();
            var car = new carDto { };
            while (dr.Read())
            {
                res.Add(car = new carDto
                {
                    Id = dr.GetInt32("Id"),
                    Brand = dr.GetString("Brand"),
                    Type = dr.GetString("Type"),
                    License = dr.GetString("License"),
                    Date = dr.GetInt32("Date")
                });
                
             
            }
            conn._connection.Close();
            return new { res };
        }

        [HttpGet("GetWitLicense")]
        public object GetWithLicense()
        {
            conn._connection.Open();
            List<object> res = new List<object>();
            string sql = "SELECT * FROM `cars` WHERE License LIKE '1B3CB3HA5BD580574' ";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            MySqlDataReader dr = cmd.ExecuteReader();
            var car = new carDto { };
            while (dr.Read())
            {
                res.Add(car = new carDto
                {
                    Id = dr.GetInt32("Id"),
                    Brand = dr.GetString("Brand"),
                    Type = dr.GetString("Type"),
                    License = dr.GetString("License"),
                    Date = dr.GetInt32("Date")
                });


            }
            conn._connection.Close();
            return new { res };
        }

        [HttpPut("ChevToHyun")]
        public object ChevToHyun()
        {
            conn._connection.Open();
            string sql = "UPDATE `cars` SET `Brand`='Hyundai' WHERE `Brand` = 'Chevrolet' AND `Date` > 1999";
            MySqlCommand cmd = new MySqlCommand(sql, conn._connection);
            cmd.ExecuteNonQuery();
            conn._connection.Close();
            return new { message = "ali abdul aziz" };
        }
    }
}
    