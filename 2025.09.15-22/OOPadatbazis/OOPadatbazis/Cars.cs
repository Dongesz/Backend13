using System;

namespace OOPadatbazis
{
    internal class Cars
    {
        public int Id { get; }
        public string Brand { get; }
        public string Type { get; }
        public DateTime MDate { get; }

        public Cars(int id, string brand, string type, DateTime mdate)
        {
            Id = id;
            Brand = brand;
            Type = type;
            MDate = mdate;
        }

        public override string ToString()
            => $"Brand: {Brand}, Type: {Type}, Megj.: {MDate:yyyy-MM-dd}";
    }
}
