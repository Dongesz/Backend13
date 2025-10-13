using ConsoleApp1.Services;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cars cars = new Cars();
            //Feladat1
            cars.GetAllCar();
            //Feladat2
            cars.AddCar("Mazda", "MIata", "asdasd", 2011);
            //Feladat3
            cars.UpdateCarDate(123, 2012107);
            //Feladat4
            cars.DeleteCar(257);

        }
    }
}
