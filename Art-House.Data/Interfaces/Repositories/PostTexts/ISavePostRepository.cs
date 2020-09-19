using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.PostTexts
{
    public interface ISavePostRepository : IDisposable
    {
        void Insert(SavePost entity);
        IEnumerable<SavePost> Take(int count);
        void Update(SavePost entity);
        void Delete(object id);
        void Delete(SavePost entity);
        void Delete(Expression<Func<SavePost, bool>> where);
        SavePost GetById(object id);
        IEnumerable<SavePost> GetAll();
        IEnumerable<SavePost> Where(Expression<Func<SavePost, bool>> where);

        #region Asyncs

        Task InsertAsync(SavePost entity);

        Task<SavePost> GetByIdAsync(object id);
        Task<IEnumerable<SavePost>> GetAllAsync();
        Task<SavePost> GetAsync(Expression<Func<SavePost, bool>> where);
        Task<ICollection<SavePost>> GetAllAsync(Expression<Func<SavePost, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
