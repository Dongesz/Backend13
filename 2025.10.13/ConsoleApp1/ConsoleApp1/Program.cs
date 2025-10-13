using ConsoleApp1.Services;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cars cars = new Cars();
            //Feladat1 Kérdezze le az összes autó Márkáját és azonosítóját,
            cars.GetAllCar();
            //Feladat2 Adjon hozzá egy új autót az adatbázishoz,
            cars.AddCar("Mazda", "Miata", "3573467", 2011);
            //Feladat3 Módosítsa a 123. azonosítójú autó gyártási évét,
            cars.UpdateCarDate(123, 2012107);
            //Feladat4 Törölje az 257-es id-val rendelkező autó adatait.
            cars.DeleteCar(257);

        }
    }
}
