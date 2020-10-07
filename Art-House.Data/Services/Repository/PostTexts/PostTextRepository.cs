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
    public class PostTextRepository : IPostTextRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public PostTextRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.PostText.CountAsync();
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

        public void Delete(PostText entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.PostText.Remove(entity);
        }

        public void Delete(Expression<Func<PostText, bool>> where)
        {
            IEnumerable<PostText> entities = _db.PostText.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<PostText> GetAll()
        {
            return _db.PostText.Include(a => a.Groups).Include(a=>a.Users).Include(p=>p.SavePosts).AsEnumerable();
        }

        public async Task<IEnumerable<PostText>> GetAllAsync()
        {
            return await _db.PostText.Include(a=>a.Groups).Include(a => a.Users).Include(p => p.SavePosts).ToListAsync();
        }

        public async Task<ICollection<PostText>> GetAllAsync(Expression<Func<PostText, bool>> match)
        {
            return await _db.PostText.Include(a => a.Groups).Include(a => a.Users).Include(p => p.SavePosts).Where(match).ToListAsync();
        }

        public async Task<PostText> GetAsync(Expression<Func<PostText, bool>> where)
        {
            return await _db.PostText.Where(where).FirstOrDefaultAsync();
        }

        public PostText GetById(object id)
        {
            return _db.PostText.Find(id);
        }

        public async Task<PostText> GetByIdAsync(object id)
        {
            return await _db.PostText.FindAsync(id);
        }

        public void Insert(PostText entity)
        {
            _db.PostText.Add(entity);
        }

        public async Task InsertAsync(PostText entity)
        {
            await _db.PostText.AddAsync(entity);
        }

        public IEnumerable<PostText> Take(int count)
        {
            return _db.PostText.Take(count);
        }

        public void Update(PostText entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.PostText.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<PostText> Where(Expression<Func<PostText, bool>> where)
        {
            IQueryable<PostText> entities = _db.PostText.Include(p=>p.Users).Include(p=>p.Groups).Include(p=>p.SavePosts);
            if (where != null)
            {
                entities = entities.Where(where);
            }

            return entities.AsEnumerable();
        }
        public IEnumerable<PostText> Paging(int pageid,int take, IEnumerable<PostText> post)
        {
            var skip = (pageid - 1) * 25;
            return post.Where(p => !p.IsDeleted).Take(take).Skip(skip).OrderByDescending(p => p.CreatedTime);
        }

        public IEnumerable<PostText> Paging(int pageid,int take)
        {
            var skip = (pageid - 1) * take;
            return _db.PostText.Where(a => !a.IsDeleted).Skip(skip).Take(take).OrderByDescending(p=>p.CreatedTime).ToList();
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
        ~PostTextRepository()
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
