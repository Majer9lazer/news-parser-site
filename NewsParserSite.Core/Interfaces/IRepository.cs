using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParserSite.Core.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        List<T> GetAll();
        T GetEntityById(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void Save();
    }
}
