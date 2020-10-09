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
   public class BtnQuestionRepository: IBtnQuestionRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public BtnQuestionRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.BtnQuestion.CountAsync();
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

        public void Delete(BtnQuestion entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.BtnQuestion.Remove(entity);
        }

        public void Delete(Expression<Func<BtnQuestion, bool>> where)
        {
            IEnumerable<BtnQuestion> entities = _db.BtnQuestion.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<BtnQuestion> GetAll()
        {
            return _db.BtnQuestion.Include(p=>p.Questions).Include(p=>p.UserAnswer).AsEnumerable();
        }

        public async Task<IEnumerable<BtnQuestion>> GetAllAsync()
        {
            return await _db.BtnQuestion.Include(p => p.Questions).Include(p => p.UserAnswer).ToListAsync();
        }

        public async Task<ICollection<BtnQuestion>> GetAllAsync(Expression<Func<BtnQuestion, bool>> match)
        {
            return await _db.BtnQuestion.Include(p => p.Questions).Include(p => p.UserAnswer).Where(match).ToListAsync();
        }

        public async Task<BtnQuestion> GetAsync(Expression<Func<BtnQuestion, bool>> where)
        {
            return await _db.BtnQuestion.Where(where).FirstOrDefaultAsync();
        }

        public BtnQuestion GetById(object id)
        {
            return _db.BtnQuestion.Find(id);
        }

        public async Task<BtnQuestion> GetByIdAsync(object id)
        {
            return await _db.BtnQuestion.FindAsync(id);
        }

        public void Insert(BtnQuestion entity)
        {
            _db.BtnQuestion.Add(entity);
        }

        public async Task InsertAsync(BtnQuestion entity)
        {
            await _db.BtnQuestion.AddAsync(entity);
        }

        public IEnumerable<BtnQuestion> Take(int count)
        {
            return _db.BtnQuestion.Take(count);
        }

        public void Update(BtnQuestion entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.BtnQuestion.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<BtnQuestion> Where(Expression<Func<BtnQuestion, bool>> where)
        {
            IQueryable<BtnQuestion> entities = _db.BtnQuestion;
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
        ~BtnQuestionRepository()
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
