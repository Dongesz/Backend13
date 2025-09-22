using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPadatbazis.services
{
    internal interface ISqlStatement
    {
        List<Book> GetAllBooks();
        List<Book> GetById(int id);
    }
}
