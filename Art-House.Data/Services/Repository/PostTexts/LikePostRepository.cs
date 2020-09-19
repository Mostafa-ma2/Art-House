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
   public class LikePostRepository:ILikePostRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public LikePostRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.likePosts.CountAsync();
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

        public void Delete(likePost entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.likePosts.Remove(entity);
        }

        public void Delete(Expression<Func<likePost, bool>> where)
        {
            IEnumerable<likePost> entities = _db.likePosts.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<likePost> GetAll()
        {
            return _db.likePosts.AsEnumerable();
        }

        public async Task<IEnumerable<likePost>> GetAllAsync()
        {
            return await _db.likePosts.ToListAsync();
        }

        public async Task<ICollection<likePost>> GetAllAsync(Expression<Func<likePost, bool>> match)
        {
            return await _db.likePosts.Where(match).ToListAsync();
        }

        public async Task<likePost> GetAsync(Expression<Func<likePost, bool>> where)
        {
            return await _db.likePosts.Where(where).FirstOrDefaultAsync();
        }

        public likePost GetById(object id)
        {
            return _db.likePosts.Find(id);
        }

        public async Task<likePost> GetByIdAsync(object id)
        {
            return await _db.likePosts.FindAsync(id);
        }

        public void Insert(likePost entity)
        {
            _db.likePosts.Add(entity);
        }

        public async Task InsertAsync(likePost entity)
        {
            await _db.likePosts.AddAsync(entity);
        }

        public IEnumerable<likePost> Take(int count)
        {
            return _db.likePosts.Take(count);
        }

        public void Update(likePost entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.likePosts.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<likePost> Where(Expression<Func<likePost, bool>> where)
        {
            IQueryable<likePost> entities = _db.likePosts;
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
        ~LikePostRepository()
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
