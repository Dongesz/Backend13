using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace OOPadatbazis.services
{
    internal class TableBooks : ISqlStatement<Book>
    {
        private readonly MySqlConnection _conn;
        public TableBooks(MySqlConnection conn) { _conn = conn; }

        public long AddNewRecords(Book newBook)
        {
            const string sql = @"INSERT INTO books (title, author, releaseDate)
                                 VALUES (@title, @author, @release)";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = newBook.Title;
            cmd.Parameters.Add("@author", MySqlDbType.VarChar).Value = newBook.Author;
            cmd.Parameters.Add("@release", MySqlDbType.DateTime).Value = newBook.ReleaseDate;

            cmd.ExecuteNonQuery();
            return cmd.LastInsertedId;
        }

        public bool DeleteById(int id)
        {
            const string sql = "DELETE FROM books WHERE id = @id";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            return cmd.ExecuteNonQuery() > 0;
        }

        public List<Book> GetAllRecords()
        {
            var result = new List<Book>();
            const string sql = "SELECT id, title, author, releaseDate FROM books";
            using var cmd = new MySqlCommand(sql, _conn);
            using var reader = cmd.ExecuteReader();

            int ixId = reader.GetOrdinal("id");
            int ixTitle = reader.GetOrdinal("title");
            int ixAuthor = reader.GetOrdinal("author");
            int ixRelease = reader.GetOrdinal("releaseDate");

            while (reader.Read())
            {
                var book = new Book(
                    reader.GetInt32(ixId),
                    reader.GetString(ixTitle),
                    reader.GetString(ixAuthor),
                    reader.IsDBNull(ixRelease) ? DateTime.MinValue : reader.GetDateTime(ixRelease)
                );
                result.Add(book);
            }
            return result;
        }

        public Book? GetById(int id)
        {
            const string sql = @"SELECT id, title, author, releaseDate
                                 FROM books
                                 WHERE id = @id
                                 LIMIT 1";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            int ixId = reader.GetOrdinal("id");
            int ixTitle = reader.GetOrdinal("title");
            int ixAuthor = reader.GetOrdinal("author");
            int ixRelease = reader.GetOrdinal("releaseDate");

            return new Book(
                reader.GetInt32(ixId),
                reader.GetString(ixTitle),
                reader.GetString(ixAuthor),
                reader.IsDBNull(ixRelease) ? DateTime.MinValue : reader.GetDateTime(ixRelease)
            );
        }

        public bool UpdateRecord(int id, Book update)
        {
            const string sql = @"UPDATE books
                                 SET title = @title,
                                     author = @author,
                                     releaseDate = @release
                                 WHERE id = @id";
            using var cmd = new MySqlCommand(sql, _conn);
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = update.Title;
            cmd.Parameters.Add("@author", MySqlDbType.VarChar).Value = update.Author;
            cmd.Parameters.Add("@release", MySqlDbType.Date).Value = update.ReleaseDate;

            return cmd.ExecuteNonQuery() > 0;
        }
    }
}
