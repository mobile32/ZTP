using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace PizzaStore.DAL.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(ObjectId id);
        IEnumerable<T> GetByQuery(Expression<Func<T,bool>> predicate);
        void Add(T item);
        void Remove(ObjectId id);
    }
}