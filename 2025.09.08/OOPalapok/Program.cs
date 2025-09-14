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
            set => _age = value < 0 ? 0 : value;

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
            set => _balance = value < 0 ? 0 : value;
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

        public Hallgato(string name, int age, string neptunecode) : base(name, age)
        {

            _neptunecode = neptunecode;
        }
        
        public string ToString()
        {
            return $"Ez itt a nevem:{_name}, ez prdig a neptune codeom: {_neptunecode}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Szemely person = new Szemely("Peti", 14);
            Console.WriteLine(person.ToString());
        }
    }
}
