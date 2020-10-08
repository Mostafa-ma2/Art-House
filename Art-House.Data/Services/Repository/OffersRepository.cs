using Art_House.Data.Context;
using Art_House.Data.Interfaces.Repositories;
using Art_House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Services.Repository
{
   public class OffersRepository: IOffersRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public OffersRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.Offers.CountAsync();
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("there is no entity with this id");
            }
            Delete(entity);
        }

        public void Delete(Offers entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.Offers.Remove(entity);
        }

        public void Delete(Expression<Func<Offers, bool>> where)
        {
            IEnumerable<Offers> entities = _db.Offers.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<Offers> GetAll()
        {
            return _db.Offers.Include(p=>p.Users).AsEnumerable();
        }

        public async Task<IEnumerable<Offers>> GetAllAsync()
        {
            return await _db.Offers.Include(p => p.Users).ToListAsync();
        }

        public async Task<ICollection<Offers>> GetAllAsync(Expression<Func<Offers, bool>> match)
        {
            return await _db.Offers.Include(p => p.Users).Where(match).ToListAsync();
        }

        public async Task<Offers> GetAsync(Expression<Func<Offers, bool>> where)
        {
            return await _db.Offers.Where(where).FirstOrDefaultAsync();
        }

        public Offers GetById(object id)
        {
            return _db.Offers.Find(id);
        }

        public async Task<Offers> GetByIdAsync(object id)
        {
            return await _db.Offers.FindAsync(id);
        }

        public void Insert(Offers entity)
        {
            _db.Offers.Add(entity);
        }

        public async Task InsertAsync(Offers entity)
        {
            await _db.Offers.AddAsync(entity);
        }

        public IEnumerable<Offers> Take(int count)
        {
            return _db.Offers.Take(count);
        }

        public void Update(Offers entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Offers.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Offers> Where(Expression<Func<Offers, bool>> where)
        {
            IQueryable<Offers> entities = _db.Offers;
            if (where != null)
            {
                entities = entities.Where(where);
            }

            return entities.AsEnumerable();
        }

        #region IDisposable Support

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _db.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposedValue = true;
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~OffersRepository()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
