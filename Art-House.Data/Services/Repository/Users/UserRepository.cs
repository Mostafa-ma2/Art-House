using Art_House.Data.Context;
using Art_House.Data.Interfaces.Repositories.Users;
using Art_House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Services.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public UserRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.User.CountAsync();
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

        public void Delete(User entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.User.Remove(entity);
        }

        public void Delete(Expression<Func<User, bool>> where)
        {
            IEnumerable<User> entities = _db.User.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _db.User.Include(a=>a.PostTexts).Include(a=>a.UserInUsers).AsEnumerable();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _db.User.Include(a => a.PostTexts).Include(a => a.UserInUsers).ToListAsync();
        }

        public async Task<ICollection<User>> GetAllAsync(Expression<Func<User, bool>> match)
        {
            return await _db.User.Include(a => a.PostTexts).Include(a => a.UserInUsers).Where(match).ToListAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> where)
        {
            return await _db.User.Where(where).FirstOrDefaultAsync();
        }

        public User GetById(object id)
        {
            return _db.User.Find(id);
        }

        public async Task<User> GetByIdAsync(object id)
        {
            return await _db.User.FindAsync(id);
        }

        public void Insert(User entity)
        {
            _db.User.Add(entity);
        }

        public async Task InsertAsync(User entity)
        {
            await _db.User.AddAsync(entity);
        }

        public IEnumerable<User> Take(int count)
        {
            return _db.User.Take(count);
        }

        public void Update(User entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.User.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<User> Where(Expression<Func<User, bool>> where)
        {
            IQueryable<User> entities = _db.User;
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
        ~UserRepository()
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
