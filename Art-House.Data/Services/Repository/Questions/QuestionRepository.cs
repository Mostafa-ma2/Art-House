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
   public class QuestionRepository: IQuestionsRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public QuestionRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.Question.CountAsync();
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

        public void Delete(Question entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.Question.Remove(entity);
        }

        public void Delete(Expression<Func<Question, bool>> where)
        {
            IEnumerable<Question> entities = _db.Question.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<Question> GetAll()
        {
            return _db.Question.Include(p=>p.BtnQuestions).AsEnumerable();
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _db.Question.Include(p => p.BtnQuestions).ToListAsync();
        }

        public async Task<ICollection<Question>> GetAllAsync(Expression<Func<Question, bool>> match)
        {
            return await _db.Question.Include(p => p.BtnQuestions).Where(match).ToListAsync();
        }

        public async Task<Question> GetAsync(Expression<Func<Question, bool>> where)
        {
            return await _db.Question.Where(where).FirstOrDefaultAsync();
        }

        public Question GetById(object id)
        {
            return _db.Question.Find(id);
        }

        public async Task<Question> GetByIdAsync(object id)
        {
            return await _db.Question.FindAsync(id);
        }

        public void Insert(Question entity)
        {
            _db.Question.Add(entity);
        }

        public async Task InsertAsync(Question entity)
        {
            await _db.Question.AddAsync(entity);
        }

        public IEnumerable<Question> Take(int count)
        {
            return _db.Question.Take(count);
        }

        public void Update(Question entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Question.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Question> Where(Expression<Func<Question, bool>> where)
        {
            IQueryable<Question> entities = _db.Question;
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
        ~QuestionRepository()
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
