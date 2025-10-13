using ConsoleApp1.Services;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cars cars = new Cars();

            cars.GetAllCar();
            cars.AddCar("Mazda", "MIata", "asdasd", 2011);
            cars.UpdateCar(301, "Mitsubishi", "Eclips", "asdasdasd", 2007);
            cars.DeleteCar(302);
            cars.DeleteCar(303);
            cars.DeleteCar(304);
            cars.DeleteCar(305);
            cars.DeleteCar(306);
        }
    }
}
