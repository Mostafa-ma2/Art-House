using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories
{
   public interface IGroupRepository:IDisposable
    {
        void Insert(Groups entity);
        IEnumerable<Groups> Take(int count);
        void Update(Groups entity);
        void Delete(object id);
        void Delete(Groups entity);
        void Delete(Expression<Func<Groups, bool>> where);
        Groups GetById(object id);
        IEnumerable<Groups> GetAll();
        IEnumerable<Groups> Where(Expression<Func<Groups, bool>> where);

        #region Asyncs

        Task InsertAsync(Groups entity);
        Task<Groups> GetByIdAsync(object id);
        Task<IEnumerable<Groups>> GetAllAsync();
        Task<Groups> GetAsync(Expression<Func<Groups, bool>> where);
        Task<ICollection<Groups>> GetAllAsync(Expression<Func<Groups, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
