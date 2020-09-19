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
   public class UserAnswerReposiitory: IUserAnswerRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public UserAnswerReposiitory(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.UserAnswer.CountAsync();
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

        public void Delete(userAnswer entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.UserAnswer.Remove(entity);
        }

        public void Delete(Expression<Func<userAnswer, bool>> where)
        {
            IEnumerable<userAnswer> entities = _db.UserAnswer.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<userAnswer> GetAll()
        {
            return _db.UserAnswer.AsEnumerable();
        }

        public async Task<IEnumerable<userAnswer>> GetAllAsync()
        {
            return await _db.UserAnswer.ToListAsync();
        }

        public async Task<ICollection<userAnswer>> GetAllAsync(Expression<Func<userAnswer, bool>> match)
        {
            return await _db.UserAnswer.Where(match).ToListAsync();
        }

        public async Task<userAnswer> GetAsync(Expression<Func<userAnswer, bool>> where)
        {
            return await _db.UserAnswer.Where(where).FirstOrDefaultAsync();
        }

        public userAnswer GetById(object id)
        {
            return _db.UserAnswer.Find(id);
        }

        public async Task<userAnswer> GetByIdAsync(object id)
        {
            return await _db.UserAnswer.FindAsync(id);
        }

        public void Insert(userAnswer entity)
        {
            _db.UserAnswer.Add(entity);
        }

        public async Task InsertAsync(userAnswer entity)
        {
            await _db.UserAnswer.AddAsync(entity);
        }

        public IEnumerable<userAnswer> Take(int count)
        {
            return _db.UserAnswer.Take(count);
        }

        public void Update(userAnswer entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.UserAnswer.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<userAnswer> Where(Expression<Func<userAnswer, bool>> where)
        {
            IQueryable<userAnswer> entities = _db.UserAnswer;
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
        ~UserAnswerReposiitory()
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
