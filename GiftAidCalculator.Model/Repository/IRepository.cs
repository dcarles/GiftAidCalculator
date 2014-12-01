using System;
using System.Linq;
using System.Linq.Expressions;

namespace GiftAidCalculator.Model
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
    }
}