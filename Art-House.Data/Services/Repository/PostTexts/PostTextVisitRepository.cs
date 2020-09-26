using Art_House.Data.Context;
using Art_House.Data.Interfaces.Repositories.PostTexts;
using Art_House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Services.Repository.PostTexts
{
    public class PostTextVisitRepository : IPostTextVisitRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public PostTextVisitRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.PostTextVisits.CountAsync();
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

        public void Delete(PostTextVisit entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.PostTextVisits.Remove(entity);
        }

        public void Delete(Expression<Func<PostTextVisit, bool>> where)
        {
            IEnumerable<PostTextVisit> entities = _db.PostTextVisits.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<PostTextVisit> GetAll()
        {
            return _db.PostTextVisits.AsEnumerable();
        }

        public async Task<IEnumerable<PostTextVisit>> GetAllAsync()
        {
            return await _db.PostTextVisits.ToListAsync();
        }

        public async Task<ICollection<PostTextVisit>> GetAllAsync(Expression<Func<PostTextVisit, bool>> match)
        {
            return await _db.PostTextVisits.Where(match).ToListAsync();
        }

        public async Task<PostTextVisit> GetAsync(Expression<Func<PostTextVisit, bool>> where)
        {
            return await _db.PostTextVisits.Where(where).FirstOrDefaultAsync();
        }

        public PostTextVisit GetById(object id)
        {
            return _db.PostTextVisits.Find(id);
        }

        public async Task<PostTextVisit> GetByIdAsync(object id)
        {
            return await _db.PostTextVisits.FindAsync(id);
        }

        public void Insert(PostTextVisit entity)
        {
            _db.PostTextVisits.Add(entity);
        }

        public async Task InsertAsync(PostTextVisit entity)
        {
            await _db.PostTextVisits.AddAsync(entity);
        }

        public IEnumerable<PostTextVisit> Take(int count)
        {
            return _db.PostTextVisits.Take(count);
        }

        public void Update(PostTextVisit entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.PostTextVisits.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<PostTextVisit> Where(Expression<Func<PostTextVisit, bool>> where)
        {
            IQueryable<PostTextVisit> entities = _db.PostTextVisits;
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
        ~PostTextVisitRepository()
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
