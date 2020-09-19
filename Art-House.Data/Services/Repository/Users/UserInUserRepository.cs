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
   public class UserInUserRepository:IUserInUserRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public UserInUserRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.UserInUser.CountAsync();
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

        public void Delete(UserInUser entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.UserInUser.Remove(entity);
        }

        public void Delete(Expression<Func<UserInUser, bool>> where)
        {
            IEnumerable<UserInUser> entities = _db.UserInUser.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<UserInUser> GetAll()
        {
            return _db.UserInUser.AsEnumerable();
        }

        public async Task<IEnumerable<UserInUser>> GetAllAsync()
        {
            return await _db.UserInUser.ToListAsync();
        }

        public async Task<ICollection<UserInUser>> GetAllAsync(Expression<Func<UserInUser, bool>> match)
        {
            return await _db.UserInUser.Where(match).ToListAsync();
        }

        public async Task<UserInUser> GetAsync(Expression<Func<UserInUser, bool>> where)
        {
            return await _db.UserInUser.Where(where).FirstOrDefaultAsync();
        }

        public UserInUser GetById(object id)
        {
            return _db.UserInUser.Find(id);
        }

        public async Task<UserInUser> GetByIdAsync(object id)
        {
            return await _db.UserInUser.FindAsync(id);
        }

        public void Insert(UserInUser entity)
        {
            _db.UserInUser.Add(entity);
        }

        public async Task InsertAsync(UserInUser entity)
        {
            await _db.UserInUser.AddAsync(entity);
        }

        public IEnumerable<UserInUser> Take(int count)
        {
            return _db.UserInUser.Take(count);
        }

        public void Update(UserInUser entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.UserInUser.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<UserInUser> Where(Expression<Func<UserInUser, bool>> where)
        {
            IQueryable<UserInUser> entities = _db.UserInUser;
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
        ~UserInUserRepository()
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
