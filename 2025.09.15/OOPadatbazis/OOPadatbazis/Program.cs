using System;
using OOPadatbazis;
using OOPadatbazis.services;

namespace OOPadatbazis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DB kapcsolat
            var db = DbConnection.Instance();
            db.Server = "localhost";
            db.DatabaseName = "library";
            db.UserName = "root";
            db.Password = "";

            if (!db.IsConnect())
            {
                Console.WriteLine("Nem sikerült csatlakozni az adatbázishoz.");
                return;
            }

            var books = new TableBooks(db.Connection);
            var cars = new TableCars(db.Connection);

            Console.WriteLine("Parancsok: b-getall, b-get, b-add, b-upd, b-del, c-getall, c-get, c-add, c-upd, c-del, q");

            while (true)
            {
                Console.Write("> ");
                var cmd = (Console.ReadLine() ?? "").Trim().ToLower();

                if (cmd == "q") break;

                try
                {
                    switch (cmd)
                    {
                        case "b-getall":
                            {
                                var list = books.GetAllRecords();
                                if (list.Count == 0) { Console.WriteLine("(nincs könyv)"); break; }
                                foreach (var x in list) Console.WriteLine(x);
                                break;
                            }
                        case "b-get":
                            {
                                Console.Write("id: "); var id = int.Parse(Console.ReadLine()!);
                                var x = books.GetById(id);
                                Console.WriteLine(x is null ? "nincs ilyen" : x.ToString());
                                break;
                            }
                        case "b-add":
                            {
                                Console.Write("cím: "); var title = Console.ReadLine()!;
                                Console.Write("szerző: "); var author = Console.ReadLine()!;
                                Console.Write("megj (yyyy-MM-dd): "); var dt = DateTime.Parse(Console.ReadLine()!);
                                var id = books.AddNewRecords(new Book(0, title, author, dt));
                                Console.WriteLine($"hozzáadva, id={id}");
                                break;
                            }
                        case "b-upd":
                            {
                                Console.Write("id: "); var id = int.Parse(Console.ReadLine()!);
                                Console.Write("új cím: "); var title = Console.ReadLine()!;
                                Console.Write("új szerző: "); var author = Console.ReadLine()!;
                                Console.Write("új megj (yyyy-MM-dd): "); var dt = DateTime.Parse(Console.ReadLine()!);
                                var ok = books.UpdateRecord(id, new Book(id, title, author, dt));
                                Console.WriteLine(ok ? "ok" : "nincs módosítás");
                                break;
                            }
                        case "b-del":
                            {
                                Console.Write("id: "); var id = int.Parse(Console.ReadLine()!);
                                var ok = books.DeleteById(id);
                                Console.WriteLine(ok ? "törölve" : "nem történt törlés");
                                break;
                            }

                        case "c-getall":
                            {
                                var list = cars.GetAllRecords();
                                if (list.Count == 0) { Console.WriteLine("(nincs autó)"); break; }
                                foreach (var x in list) Console.WriteLine(x);
                                break;
                            }
                        case "c-get":
                            {
                                Console.Write("id: "); var id = int.Parse(Console.ReadLine()!);
                                var x = cars.GetById(id);
                                Console.WriteLine(x is null ? "nincs ilyen" : x.ToString());
                                break;
                            }
                        case "c-add":
                            {
                                Console.Write("brand: "); var brand = Console.ReadLine()!;
                                Console.Write("type: "); var type = Console.ReadLine()!;
                                Console.Write("mdate (yyyy-MM-dd): "); var dt = DateTime.Parse(Console.ReadLine()!);
                                var id = cars.AddNewRecords(new Cars(0, brand, type, dt));
                                Console.WriteLine($"hozzáadva, id={id}");
                                break;
                            }
                        case "c-upd":
                            {
                                Console.Write("id: "); var id = int.Parse(Console.ReadLine()!);
                                Console.Write("új brand: "); var brand = Console.ReadLine()!;
                                Console.Write("új type: "); var type = Console.ReadLine()!;
                                Console.Write("új mdate (yyyy-MM-dd): "); var dt = DateTime.Parse(Console.ReadLine()!);
                                var ok = cars.UpdateRecord(id, new Cars(id, brand, type, dt));
                                Console.WriteLine(ok ? "ok" : "nincs módosítás");
                                break;
                            }
                        case "c-del":
                            {
                                Console.Write("id: "); var id = int.Parse(Console.ReadLine()!);
                                var ok = cars.DeleteById(id);
                                Console.WriteLine(ok ? "törölve" : "nem történt törlés");
                                break;
                            }

                        default:
                            Console.WriteLine("Ismeretlen parancs!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hiba: " + ex.Message);
                }
            }

            db.Close();
        }
    }
}
