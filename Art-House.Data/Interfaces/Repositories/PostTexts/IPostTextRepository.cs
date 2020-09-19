using System;
using System.Collections.Generic;
using Art_House.Domain.Entities;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.PostTexts
{
    public interface IPostTextRepository : IDisposable
    {
        void Insert(PostText entity);
        IEnumerable<PostText> Take(int count);
        void Update(PostText entity);
        void Delete(object id);
        void Delete(PostText entity);
        void Delete(Expression<Func<PostText, bool>> where);
        PostText GetById(object id);
        IEnumerable<PostText> GetAll();
        IEnumerable<PostText> Where(Expression<Func<PostText, bool>> where);

        #region Asyncs

        Task InsertAsync(PostText entity);

        Task<PostText> GetByIdAsync(object id);
        Task<IEnumerable<PostText>> GetAllAsync();
        Task<PostText> GetAsync(Expression<Func<PostText, bool>> where);
        Task<ICollection<PostText>> GetAllAsync(Expression<Func<PostText, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
