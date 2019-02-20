using System;

namespace NewsParserSite.Core.Interfaces
{
    public interface ITransactionRepository<in T> where T : class
    {
        void TranAdd(T obj);
        void TranUpdate(T obj);
        void TranUpdate(int id, T obj);
        void TranDelete(T obj);

    }
}