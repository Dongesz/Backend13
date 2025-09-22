using System.Data;
using System.Data.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
using OOPadatbazis.services;
using Org.BouncyCastle.Tls;

namespace OOPadatbazis
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Program.Main – csak a lényeg
            var dbCon = DbConnection.Instance();
            dbCon.Server = "localhost";
            dbCon.DatabaseName = "library";
            dbCon.UserName = "root";
            dbCon.Password = "";

            if (dbCon.IsConnect())
            {
                Console.WriteLine("Successful connection!");
                ISqlStatement sqlStatement = new TableBooks(dbCon.Connection);

                // GetAllBooks
                var books = sqlStatement.GetAllBooks();
                foreach (var b in books)
                {
                    var book = b.GetType().GetProperties();
                    Console.WriteLine(book[0].GetValue(b) + " " + book[1].GetValue(b) + " " + book[2].GetValue(b) + " " + book[3].GetValue(b));
                }
                // GetById
                var item = sqlStatement.GetById(1);
                var book1 = item[0].GetType().GetProperties();
                Console.WriteLine(book1[1].Name + ": " + book1[1].GetValue(item[0]));
                // AddNewBook
                var book2 = new { title = "harry potter", author = "JKrowling",release = new DateTime(2007, 10, 12) };
                sqlStatement.AddNewBook(book2);
                
            }

            dbCon.Close();
        }
    }
}
