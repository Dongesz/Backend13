using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    public class Szemely
    {
        private string name { get; set; }
        private int age { get; set; }

        public Szemely(string Name, int Age) 
        {
            name = Name;
            age = Age;
        }
        public string kiir()
        {
            return $"A szemely neve: {name} \nEletkora: {age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Szemely person = new Szemely("Peti", 20);
            Console.WriteLine(person.kiir());
        }
    }
}
