using MySql.Data.MySqlClient;
using OOPadatbazis.services;
using OOPadatbazis;

internal class TableBooks : ISqlStatement
{
    private readonly MySqlConnection _conn;
    public TableBooks(MySqlConnection conn) { _conn = conn; }

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
}