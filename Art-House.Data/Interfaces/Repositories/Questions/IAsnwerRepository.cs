using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.Questions
{
   public interface IAsnwerRepository:IDisposable
    {
        void Insert(Asnwer entity);
        IEnumerable<Asnwer> Take(int count);
        void Update(Asnwer entity);
        void Delete(object id);
        void Delete(Asnwer entity);
        void Delete(Expression<Func<Asnwer, bool>> where);
        Asnwer GetById(object id);
        IEnumerable<Asnwer> GetAll();
        IEnumerable<Asnwer> Where(Expression<Func<Asnwer, bool>> where);

        #region Asyncs

        Task InsertAsync(Asnwer entity);

        Task<Asnwer> GetByIdAsync(object id);
        Task<IEnumerable<Asnwer>> GetAllAsync();
        Task<Asnwer> GetAsync(Expression<Func<Asnwer, bool>> where);
        Task<ICollection<Asnwer>> GetAllAsync(Expression<Func<Asnwer, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
