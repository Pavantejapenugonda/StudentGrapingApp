using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC440_F2023_Project.Model
{
    public class GenericDataService<T> : IDataService<T>, IDisposable where T : class
    {
        readonly private StudentContext _dbContext;

        public GenericDataService()
        {
            _dbContext = new StudentContext();
        }
        public bool Delete(int id)
        {
            try
            {
                var entity = _dbContext.Set<T>().Find(id);
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
                return true;
            } catch { }
            return false;
            throw new NotImplementedException();
        }
        public T Get(int id)
        { 
            try
            {
                var data = _dbContext.Set<T>().Find(id);
                _dbContext.Entry(data).State = EntityState.Detached;
                return data;
            } catch { }
            return null;
        }
        public IEnumerable<T> GetAll()
        {
            try
            {
                var data = _dbContext.Set<T>().AsNoTracking().ToList();
                return data;
            }
            catch { }
            return null;
        }
        public T Update(int id, T entity)
        {
            try
            {
                var result = _dbContext.Update(entity);
                _dbContext.SaveChanges();
                return (T)result.Entity;
            }
            catch { }
            return null;
        }
        public T Create(T _entity)
        {
            try
            {
                var result = _dbContext.Add(_entity);
                _dbContext.SaveChanges();
                return (T)result.Entity;
            }
            catch { }
            return null;
        }
        public T ExeStoredProcedure(string sql, List<SqlParameter> list)
        {
            try
            {
                var result = _dbContext.Set<T>().FromSqlRaw<T>(sql, list.ToArray()).ToList();
                if (result!=null && result.Count > 0)
                    return (T)result[0];
            }
            catch { }
            return null;
        }
        public void Dispose()
        {
            try { _dbContext.Dispose(); } catch { }
        }
    }
}
