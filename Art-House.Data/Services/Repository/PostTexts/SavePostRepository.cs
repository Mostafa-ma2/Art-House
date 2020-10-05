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
   public class SavePostRepository:ISavePostRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public SavePostRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.SavePosts.CountAsync();
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

        public void Delete(SavePost entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.SavePosts.Remove(entity);
        }

        public void Delete(Expression<Func<SavePost, bool>> where)
        {
            IEnumerable<SavePost> entities = _db.SavePosts.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<SavePost> GetAll()
        {
            return _db.SavePosts.Include(p=>p.PostTexts).AsEnumerable();
        }

        public async Task<IEnumerable<SavePost>> GetAllAsync()
        {
            return await _db.SavePosts.Include(p => p.PostTexts).ToListAsync();
        }

        public async Task<ICollection<SavePost>> GetAllAsync(Expression<Func<SavePost, bool>> match)
        {
            return await _db.SavePosts.Include(p => p.PostTexts).Where(match).ToListAsync();
        }

        public async Task<SavePost> GetAsync(Expression<Func<SavePost, bool>> where)
        {
            return await _db.SavePosts.Where(where).FirstOrDefaultAsync();
        }

        public SavePost GetById(object id)
        {
            return _db.SavePosts.Find(id);
        }

        public async Task<SavePost> GetByIdAsync(object id)
        {
            return await _db.SavePosts.FindAsync(id);
        }

        public void Insert(SavePost entity)
        {
            _db.SavePosts.Add(entity);
        }

        public async Task InsertAsync(SavePost entity)
        {
            await _db.SavePosts.AddAsync(entity);
        }

        public IEnumerable<SavePost> Take(int count)
        {
            return _db.SavePosts.Take(count);
        }

        public void Update(SavePost entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.SavePosts.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<SavePost> Where(Expression<Func<SavePost, bool>> where)
        {
            IQueryable<SavePost> entities = _db.SavePosts;
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
        ~SavePostRepository()
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
