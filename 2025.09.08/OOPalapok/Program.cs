using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace OOPalapok
{
    public class Szemely
    {
        private string _name;
        private int _age;
        
        public int Age
        {
            get => _age;
            set => _age = value < 0 ? 0 : value;

        }
        public Szemely(string name, int age)
        {
            _name = name;
            Age = age;
        }
        
        public string kiir()
        {
            return $"A szemely neve: {_name} \nEletkora: {Age}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Szemely person = new Szemely("Peti", 14);
            Console.WriteLine(person.kiir());
        }
    }
}
