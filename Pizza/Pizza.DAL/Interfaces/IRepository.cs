using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace Pizza.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
        IEnumerable<T> GetByQuery(Expression<Func<T,bool>> predicate);
        void Add(T item);
        void Remove(T item);
    }
}