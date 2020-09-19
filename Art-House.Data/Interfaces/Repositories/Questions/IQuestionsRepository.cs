using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.Questions
{
    public interface IQuestionsRepository : IDisposable
    {
        void Insert(Question entity);
        IEnumerable<Question> Take(int count);
        void Update(Question entity);
        void Delete(object id);
        void Delete(Question entity);
        void Delete(Expression<Func<Question, bool>> where);
        Question GetById(object id);
        IEnumerable<Question> GetAll();
        IEnumerable<Question> Where(Expression<Func<Question, bool>> where);

        #region Asyncs

        Task InsertAsync(Question entity);

        Task<Question> GetByIdAsync(object id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> GetAsync(Expression<Func<Question, bool>> where);
        Task<ICollection<Question>> GetAllAsync(Expression<Func<Question, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
