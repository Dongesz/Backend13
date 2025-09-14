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
        protected string _name;
        private int _age;
        
        public int Age
        {
            get => _age;
            set => _age = value < 0 ? throw new ArgumentOutOfRangeException(nameof(_age), "Age must be positive!") : value;

        }
        public Szemely(string name, int age)
        {
            _name = name;
            Age = age;
        }
        
        public string ToString()
        {
            return $"A szemely neve: {_name} \nEletkora: {Age}";
        }
    }
    public class BankSzamla
    {
        private int _balance;

        public int Balance
        {
            get => _balance;
            set => _balance = value < 0 ? throw new ArgumentOutOfRangeException(nameof(_balance), "Balance must be positive!") : value;
        }

        public void Betesz(int balance)
        {
            Balance += balance;
        }

        public void Kivesz(int balance)
        {
            Balance -= balance;
        }

    }
    public class Hallgato : Szemely
    {
        private string _neptunecode;

        public string NeptuneCode
        {
            get => _neptunecode;
            set => _neptunecode = value.Length > 6? throw new ArgumentOutOfRangeException(nameof(_neptunecode), "Neptun code too long!") : _neptunecode;
        }


        public Hallgato(string name, int age, string neptunecode) : base(name, age)
        {

            NeptuneCode = neptunecode;
        }
        
        public string ToString()
        {
            return $"Hallgato neve: {_name}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var hallgatok = new List<Hallgato>
            {
                new Hallgato("Peti", 19, "213145"),
                new Hallgato("Pali", 23, "223515"),
                new Hallgato("Laci", 18, "234575"),
                new Hallgato("Zsolt", 20, "293455")
            };

            foreach (var item in hallgatok)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
