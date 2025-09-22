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
                // Set up connection
                Console.WriteLine("Successful connection!");
                ISqlStatement sqlStatement = new TableBooks(dbCon.Connection);

                // GetAllBooks
                var books = sqlStatement.GetAllRecords();
                foreach (var b in books)
                {
                    var book = b.GetType().GetProperties();
                    Console.WriteLine(book[0].GetValue(b) + " " + book[1].GetValue(b) + " " + book[2].GetValue(b) + " " + book[3].GetValue(b));
                }
                // GetById
                var book1 = sqlStatement.GetById(1);
                if (book1 is null) Console.WriteLine("Nincs ilyen ID.");
                else Console.WriteLine(book1);

                // AddNewBook
                var book2 = new { title = "harry potter", author = "JKrowling",release = new DateTime(2007, 10, 12) };
                sqlStatement.AddNewRecords(book2);
                // DeleteById
                sqlStatement.DeleteById(101);
                //UpdateRecord
                var book3 = new { title = "harry potter", author = "JKrowling", release = new DateTime(2007, 10, 12) };
                sqlStatement.UpdateRecord(1, book3);

            }

            dbCon.Close();
            



        }
    }
}
