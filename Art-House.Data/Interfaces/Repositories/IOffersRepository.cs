using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories
{
   public interface IOffersRepository:IDisposable
    {
        void Insert(Offers entity);
        IEnumerable<Offers> Take(int count);
        void Update(Offers entity);
        void Delete(object id);
        void Delete(Offers entity);
        void Delete(Expression<Func<Offers, bool>> where);
        Offers GetById(object id);
        IEnumerable<Offers> GetAll();
        IEnumerable<Offers> Where(Expression<Func<Offers, bool>> where);

        #region Asyncs

        Task InsertAsync(Offers entity);
        Task<Offers> GetByIdAsync(object id);
        Task<IEnumerable<Offers>> GetAllAsync();
        Task<Offers> GetAsync(Expression<Func<Offers, bool>> where);
        Task<ICollection<Offers>> GetAllAsync(Expression<Func<Offers, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
