using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.Users
{
   public interface IUserAnswerRepository:IDisposable
    {
        void Insert(userAnswer entity);
        IEnumerable<userAnswer> Take(int count);
        void Update(userAnswer entity);
        void Delete(object id);
        void Delete(userAnswer entity);
        void Delete(Expression<Func<userAnswer, bool>> where);
        userAnswer GetById(object id);
        IEnumerable<userAnswer> GetAll();
        IEnumerable<userAnswer> Where(Expression<Func<userAnswer, bool>> where);

        #region Asyncs

        Task InsertAsync(userAnswer entity);

        Task<userAnswer> GetByIdAsync(object id);
        Task<IEnumerable<userAnswer>> GetAllAsync();
        Task<userAnswer> GetAsync(Expression<Func<userAnswer, bool>> where);
        Task<ICollection<userAnswer>> GetAllAsync(Expression<Func<userAnswer, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
