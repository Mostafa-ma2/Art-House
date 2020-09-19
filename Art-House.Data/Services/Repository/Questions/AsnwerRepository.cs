using Art_House.Data.Context;
using Art_House.Data.Interfaces.Repositories.Questions;
using Art_House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Services.Repository.Questions
{
   public class AsnwerRepository: IAsnwerRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public AsnwerRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.Asnwer.CountAsync();
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

        public void Delete(Asnwer entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.Asnwer.Remove(entity);
        }

        public void Delete(Expression<Func<Asnwer, bool>> where)
        {
            IEnumerable<Asnwer> entities = _db.Asnwer.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<Asnwer> GetAll()
        {
            return _db.Asnwer.AsEnumerable();
        }

        public async Task<IEnumerable<Asnwer>> GetAllAsync()
        {
            return await _db.Asnwer.ToListAsync();
        }

        public async Task<ICollection<Asnwer>> GetAllAsync(Expression<Func<Asnwer, bool>> match)
        {
            return await _db.Asnwer.Where(match).ToListAsync();
        }

        public async Task<Asnwer> GetAsync(Expression<Func<Asnwer, bool>> where)
        {
            return await _db.Asnwer.Where(where).FirstOrDefaultAsync();
        }

        public Asnwer GetById(object id)
        {
            return _db.Asnwer.Find(id);
        }

        public async Task<Asnwer> GetByIdAsync(object id)
        {
            return await _db.Asnwer.FindAsync(id);
        }

        public void Insert(Asnwer entity)
        {
            _db.Asnwer.Add(entity);
        }

        public async Task InsertAsync(Asnwer entity)
        {
            await _db.Asnwer.AddAsync(entity);
        }

        public IEnumerable<Asnwer> Take(int count)
        {
            return _db.Asnwer.Take(count);
        }

        public void Update(Asnwer entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Asnwer.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Asnwer> Where(Expression<Func<Asnwer, bool>> where)
        {
            IQueryable<Asnwer> entities = _db.Asnwer;
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
        ~AsnwerRepository()
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
