using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiDdd.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private ApiDddContext _context = new ApiDddContext();

        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Set<TEntity>().Remove(SelectById(id));
            _context.SaveChanges();
        }

        public IList<TEntity> SelectAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity SelectById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }


    }
}
