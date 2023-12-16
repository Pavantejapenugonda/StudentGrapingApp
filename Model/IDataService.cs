using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC440_F2023_Project.Model
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Create(T entity);
        T Update(int id, T entity);
        bool Delete(int id);
        T ExeStoredProcedure(string sql, List<SqlParameter> list);
    }
}
