using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPadatbazis.services
{
    internal interface ISqlStatement
    {
        List<Book> GetAllRecords();
        List<Book> GetById(int id);
        object AddNewRecords(object newBook);
        object DeleteById(int id);
        object UpdateRecord(int id);
    }
}
