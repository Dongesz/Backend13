using MySql.Data.MySqlClient;
using OOPadatbazis.services;
using OOPadatbazis;
using Mysqlx.Crud;
using static System.Reflection.Metadata.BlobBuilder;

internal class TableBooks : ISqlStatement
{
    private readonly MySqlConnection _conn;
    public TableBooks(MySqlConnection conn) { _conn = conn; }

    public object AddNewRecords(object newBook)
    {
        string sql = "INSERT INTO books (title, author, releaseDate) VALUES (@title, @author, @releaseDate);";
        var cmd = new MySqlCommand(sql, _conn);
        var book = newBook.GetType().GetProperties();
        cmd.Parameters.AddWithValue("@title", book[0].GetValue(newBook));
        cmd.Parameters.AddWithValue("@author", book[1].GetValue(newBook));
        cmd.Parameters.AddWithValue("@releaseDate", book[2].GetValue(newBook));

        cmd.ExecuteNonQuery();
        return book;
    }

    public object DeleteById(int id)
    {
        string sql = "delete from books where id = @id";
        MySqlCommand cmd = new MySqlCommand(sql, _conn);

        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
        return new { Message = "Successful delete!"};
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
        const string sql = "SELECT id, title, author, releaseDate FROM books WHERE id = @id LIMIT 1";
        using var cmd = new MySqlCommand(sql, _conn);
        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

        using var reader = cmd.ExecuteReader();

        if (!reader.Read())
            return null;

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


    public object UpdateRecord(int id, object updateobj)
    {
        string sql = "UPDATE books SET title = @title, author = @author, releaseDate = @releaseDate WHERE id = @id; ";
        MySqlCommand cmd = new MySqlCommand(sql, _conn);
        var book = updateobj.GetType().GetProperties();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@title", book[0]);
        cmd.Parameters.AddWithValue("@author", book[1]);
        cmd.Parameters.AddWithValue("@releaseDate", book[2]);
        cmd.ExecuteNonQuery();
        return new { Message = "Update successful!" };
        
    }
}