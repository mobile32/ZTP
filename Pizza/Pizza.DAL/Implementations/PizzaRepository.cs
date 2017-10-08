using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizza.DAL.Interfaces;

namespace Pizza.DAL.Implementations
{
    public class PizzaRepository: IPizzaRepository
    {
        public PizzaRepository()
        {
            
        }

        public Pizza GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pizza> GetByQuery(Expression<Func<Pizza, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(Pizza item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Pizza item)
        {
            throw new NotImplementedException();
        }
    }
}