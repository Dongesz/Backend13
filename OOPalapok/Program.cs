using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    public class Szemely
    {
        public string Name { get; set; }
        public int Age { get; set; }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Szemely person = new Szemely { Name = "peti", Age = 20 };
            Console.WriteLine($"A szemely neve: {person.Name}");
            Console.WriteLine($"Eletkora: {person.Age}");
        }
    }
}
