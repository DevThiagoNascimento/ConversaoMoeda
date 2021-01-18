using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Interfaces.Repositories;
using WiProTest.Infra.Data.Context;

namespace WiProTest.Infra.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly WiProTestContext context;
        public RepositoryBase(WiProTestContext _context)
        {
            context = _context;
        }

        public void Add(TEntity obj)
        {
            try
            {
                context.Set<TEntity>().Add(obj);
                context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            try
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
