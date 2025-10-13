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
        void AddCar(string brand, string type, string license, int date);
        // Read
        void GetAllCar();
        // Update
        void UpdateCar(int id, string brand, string type, string license, int date);
        // Delete
        void DeleteCar(int id);
        
    }
}
