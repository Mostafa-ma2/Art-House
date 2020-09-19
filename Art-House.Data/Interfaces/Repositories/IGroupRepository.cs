using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories
{
   public interface IGroupRepository:IDisposable
    {
        void Insert(Group entity);
        IEnumerable<Group> Take(int count);
        void Update(Group entity);
        void Delete(object id);
        void Delete(Group entity);
        void Delete(Expression<Func<Group, bool>> where);
        Group GetById(object id);
        IEnumerable<Group> GetAll();
        IEnumerable<Group> Where(Expression<Func<Group, bool>> where);

        #region Asyncs

        Task InsertAsync(Group entity);
        Task<Group> GetByIdAsync(object id);
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> GetAsync(Expression<Func<Group, bool>> where);
        Task<ICollection<Group>> GetAllAsync(Expression<Func<Group, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
