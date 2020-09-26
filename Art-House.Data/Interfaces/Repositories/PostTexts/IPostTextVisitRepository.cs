using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces.Repositories.PostTexts
{
    public interface IPostTextVisitRepository : IDisposable
    {
        void Insert(PostTextVisit entity);
        IEnumerable<PostTextVisit> Take(int count);
        void Update(PostTextVisit entity);
        void Delete(object id);
        void Delete(PostTextVisit entity);
        void Delete(Expression<Func<PostTextVisit, bool>> where);
        PostTextVisit GetById(object id);
        IEnumerable<PostTextVisit> GetAll();
        IEnumerable<PostTextVisit> Where(Expression<Func<PostTextVisit, bool>> where);

        #region Asyncs

        Task InsertAsync(PostTextVisit entity);
        Task<PostTextVisit> GetByIdAsync(object id);
        Task<IEnumerable<PostTextVisit>> GetAllAsync();
        Task<PostTextVisit> GetAsync(Expression<Func<PostTextVisit, bool>> where);
        Task<ICollection<PostTextVisit>> GetAllAsync(Expression<Func<PostTextVisit, bool>> match);
        Task<int> CountAsync();

        #endregion
    }
}
