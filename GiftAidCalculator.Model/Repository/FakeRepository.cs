using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GiftAidCalculator.Model
{
    public class FakeRepository<T> : IRepository<T> where T : class
    {
        protected List<T> Data;

        public FakeRepository()
        {
          Data = new List<T>();
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            Data.Add(entity);
        }

        public void Delete(T entity)
        {
            Data.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return Data.AsQueryable();
        }
     
        #endregion
    }
}