using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace OOPadatbazis.services
{
    internal class TableCars : ISqlStatement<Cars>
    {
        private readonly MySqlConnection _conn;
        public TableCars(MySqlConnection conn) { _conn = conn; }

        public long AddNewRecords(Cars newCar)
        {
            const string sql = @"INSERT INTO cars (brand, type, mdate)
                                 VALUES (@brand, @type, @mdate)";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = newCar.Brand;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = newCar.Type;
            cmd.Parameters.Add("@mdate", MySqlDbType.DateTime).Value = newCar.MDate;

            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public bool DeleteById(int id)
        {
            const string sql = "DELETE FROM cars WHERE id = @id";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Cars> GetAllRecords()
        {
            var result = new List<Cars>();
            const string sql = "SELECT id, brand, type, mdate FROM cars";
            using var cmd = new MySqlCommand(sql, _conn);
            using var reader = cmd.ExecuteReader();

            int ixId = reader.GetOrdinal("id");
            int ixBrand = reader.GetOrdinal("brand");
            int ixType = reader.GetOrdinal("type");
            int ixMdate = reader.GetOrdinal("mdate");

            while (reader.Read())
            {
                var car = new Cars(
                    reader.GetInt32(ixId),
                    reader.GetString(ixBrand),
                    reader.GetString(ixType),
                    reader.IsDBNull(ixMdate) ? DateTime.MinValue : reader.GetDateTime(ixMdate)
                );
                result.Add(car);
            }
            return result;
        }

        public Cars? GetById(int id)
        {
            const string sql = @"SELECT id, brand, type, mdate
                                 FROM cars
                                 WHERE id = @id
                                 LIMIT 1";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            int ixId = reader.GetOrdinal("id");
            int ixBrand = reader.GetOrdinal("brand");
            int ixType = reader.GetOrdinal("type");
            int ixMdate = reader.GetOrdinal("mdate");

            return new Cars(
                reader.GetInt32(ixId),
                reader.GetString(ixBrand),
                reader.GetString(ixType),
                reader.IsDBNull(ixMdate) ? DateTime.MinValue : reader.GetDateTime(ixMdate)
            );
        }

        public bool UpdateRecord(int id, Cars update)
        {
            const string sql = @"UPDATE cars
                                 SET brand = @brand,
                                     type  = @type,
                                     mdate = @mdate
                                 WHERE id = @id";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = update.Brand;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = update.Type;
            cmd.Parameters.Add("@mdate", MySqlDbType.Date).Value = update.MDate;

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
