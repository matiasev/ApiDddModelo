using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDdd.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private ApiDddContext _context = new ApiDddContext();

        public virtual IList<TEntity> SelectAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual async Task<IList<TEntity>> SelectAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual TEntity SelectById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> SelectByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity Insert(TEntity obj)
        {
            var res = _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
            return res.Entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity obj)
        {
            var res = await _context.Set<TEntity>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public virtual TEntity Update(TEntity obj)
        {
            var res = _context.Set<TEntity>().Update(obj);
            _context.SaveChanges();
            return res.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            var res = _context.Set<TEntity>().Update(obj);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public virtual TEntity Remove(int id)
        {
            var res = _context.Set<TEntity>().Remove(SelectById(id));
            _context.SaveChangesAsync();
            return res.Entity;
        }
    }
}
