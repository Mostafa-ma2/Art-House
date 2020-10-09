using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.Questions
{
   public interface IBtnQuestionRepository:IDisposable
    {
        void Insert(BtnQuestion entity);
        IEnumerable<BtnQuestion> Take(int count);
        void Update(BtnQuestion entity);
        void Delete(object id);
        void Delete(BtnQuestion entity);
        void Delete(Expression<Func<BtnQuestion, bool>> where);
        BtnQuestion GetById(object id);
        IEnumerable<BtnQuestion> GetAll();
        IEnumerable<BtnQuestion> Where(Expression<Func<BtnQuestion, bool>> where);

        #region Asyncs

        Task InsertAsync(BtnQuestion entity);

        Task<BtnQuestion> GetByIdAsync(object id);
        Task<IEnumerable<BtnQuestion>> GetAllAsync();
        Task<BtnQuestion> GetAsync(Expression<Func<BtnQuestion, bool>> where);
        Task<ICollection<BtnQuestion>> GetAllAsync(Expression<Func<BtnQuestion, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
