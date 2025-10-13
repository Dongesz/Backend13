using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace ConsoleApp1.Services
{
    public interface ICars
    {
        // Create
        public void AddCar(string brand, string type, string license, int date);
        // Read
        public void GetAllCar();
        // Update
        public void UpdateCar(int id, string brand, string type, string license, int date);
        // Delete
        public void DeleteCar(int id);
        
    }
}
