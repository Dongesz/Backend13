using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WfpApp.Services.Interfaces
{
    public interface IDatabaseConnection
    {
        Task<MySqlConnection> GetOpenConnectionAsync();
    }
}
