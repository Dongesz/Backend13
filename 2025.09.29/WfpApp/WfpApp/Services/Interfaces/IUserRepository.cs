using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WfpApp.Services.Interfaces
{
    internal interface IUserRepository
    {
        Task<ICollection<string>> GetDataAsync();
        Task<string> GetUserByIdAsync(int id);
        Task<bool> UpdateDataAsync(string password1, string password2, string username, string fullname, string email, int id);
        Task<bool> DeleteDataAsync(int id);
        Task<bool> CreateDataAsync(string password1, string password2, string username, string fullname, string email);



    }
}
