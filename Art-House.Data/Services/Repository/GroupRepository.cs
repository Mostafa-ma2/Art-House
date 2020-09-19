using Art_House.Data.Context;
using Art_House.Data.Interfaces.Repositories;
using Art_House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Services.Repository
{
   public class GroupsRepository: IGroupRepository
    {
        #region ctor
        private readonly DataBaseContext _db;
        public GroupsRepository(DataBaseContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<int> CountAsync()
        {
            return await _db.Groups.CountAsync();
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentException("there is no entity with this id");
            }
            Delete(entity);
        }

        public void Delete(Groups entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Attach(entity);
            }
            _db.Groups.Remove(entity);
        }

        public void Delete(Expression<Func<Groups, bool>> where)
        {
            IEnumerable<Groups> entities = _db.Groups.Where(where);
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public IEnumerable<Groups> GetAll()
        {
            return _db.Groups.AsEnumerable();
        }

        public async Task<IEnumerable<Groups>> GetAllAsync()
        {
            return await _db.Groups.ToListAsync();
        }

        public async Task<ICollection<Groups>> GetAllAsync(Expression<Func<Groups, bool>> match)
        {
            return await _db.Groups.Where(match).ToListAsync();
        }

        public async Task<Groups> GetAsync(Expression<Func<Groups, bool>> where)
        {
            return await _db.Groups.Where(where).FirstOrDefaultAsync();
        }

        public Groups GetById(object id)
        {
            return _db.Groups.Find(id);
        }

        public async Task<Groups> GetByIdAsync(object id)
        {
            return await _db.Groups.FindAsync(id);
        }

        public void Insert(Groups entity)
        {
            _db.Groups.Add(entity);
        }

        public async Task InsertAsync(Groups entity)
        {
            await _db.Groups.AddAsync(entity);
        }

        public IEnumerable<Groups> Take(int count)
        {
            return _db.Groups.Take(count);
        }

        public void Update(Groups entity)
        {
            if (_db.Entry(entity).State == EntityState.Detached)
            {
                _db.Groups.Attach(entity);
            }
            _db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<Groups> Where(Expression<Func<Groups, bool>> where)
        {
            IQueryable<Groups> entities = _db.Groups;
            if (where != null)
            {
                entities = entities.Where(where);
            }

            return entities.AsEnumerable();
        }

        #region IDisposable Support

        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _db.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposedValue = true;
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~GroupsRepository()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
