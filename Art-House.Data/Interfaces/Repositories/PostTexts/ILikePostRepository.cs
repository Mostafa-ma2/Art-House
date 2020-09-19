using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.PostTexts
{
    public interface ILikePostRepository : IDisposable
    {
        void Insert(likePost entity);
        IEnumerable<likePost> Take(int count);
        void Update(likePost entity);
        void Delete(object id);
        void Delete(likePost entity);
        void Delete(Expression<Func<likePost, bool>> where);
        likePost GetById(object id);
        IEnumerable<likePost> GetAll();
        IEnumerable<likePost> Where(Expression<Func<likePost, bool>> where);

        #region Asyncs

        Task InsertAsync(likePost entity);

        Task<likePost> GetByIdAsync(object id);
        Task<IEnumerable<likePost>> GetAllAsync();
        Task<likePost> GetAsync(Expression<Func<likePost, bool>> where);
        Task<ICollection<likePost>> GetAllAsync(Expression<Func<likePost, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
