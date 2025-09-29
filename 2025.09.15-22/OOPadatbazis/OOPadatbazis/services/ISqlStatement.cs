using System.Collections.Generic;

namespace OOPadatbazis.services
{
    internal interface ISqlStatement<T>
    {
        List<T> GetAllRecords();
        T? GetById(int id);
        long AddNewRecords(T entity);
        bool DeleteById(int id);
        bool UpdateRecord(int id, T entity);
    }

}
