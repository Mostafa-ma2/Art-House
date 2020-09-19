using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.Users
{
   public interface IUserInUserRepository:IDisposable
    {
        void Insert(UserInUser entity);
        IEnumerable<UserInUser> Take(int count);
        void Update(UserInUser entity);
        void Delete(object id);
        void Delete(UserInUser entity);
        void Delete(Expression<Func<UserInUser, bool>> where);
        UserInUser GetById(object id);
        IEnumerable<UserInUser> GetAll();
        IEnumerable<UserInUser> Where(Expression<Func<UserInUser, bool>> where);

        #region Asyncs

        Task InsertAsync(UserInUser entity);

        Task<UserInUser> GetByIdAsync(object id);
        Task<IEnumerable<UserInUser>> GetAllAsync();
        Task<UserInUser> GetAsync(Expression<Func<UserInUser, bool>> where);
        Task<ICollection<UserInUser>> GetAllAsync(Expression<Func<UserInUser, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
