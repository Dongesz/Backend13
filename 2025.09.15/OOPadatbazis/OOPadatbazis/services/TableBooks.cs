using MySql.Data.MySqlClient;
using OOPadatbazis.services;
using OOPadatbazis;

internal class TableBooks : ISqlStatement
{
    private readonly MySqlConnection _conn;
    public TableBooks(MySqlConnection conn) { _conn = conn; }

    public object AddNewBook(object newBook)
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

    public List<Book> GetAllBooks()
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

    public List<Book> GetById(int id)
    {
        var result = new List<Book>();
        string sql = "select * from books where id = @id";
        using MySqlCommand cmd = new MySqlCommand(sql, _conn);
        cmd.Parameters.AddWithValue("@id", id);
        using MySqlDataReader reader = cmd.ExecuteReader();

        int ixId = reader.GetOrdinal("id");
        int ixTitle = reader.GetOrdinal("title");
        int ixAuthor = reader.GetOrdinal("author");
        int ixRelease = reader.GetOrdinal("releaseDate");
        while(reader.Read()) 
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
}