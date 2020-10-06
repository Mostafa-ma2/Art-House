using Art_House.Data.Context;
using Art_House.Data.Interfaces;
using Art_House.Data.Interfaces.Repositories;
using Art_House.Data.Interfaces.Repositories.PostTexts;
using Art_House.Data.Interfaces.Repositories.Questions;
using Art_House.Data.Interfaces.Repositories.Users;
using Art_House.Data.Services.Repository;
using Art_House.Data.Services.Repository.PostTexts;
using Art_House.Data.Services.Repository.Questions;
using Art_House.Data.Services.Repository.Users;
using System;
using System.Threading.Tasks;

namespace Art_House.Data.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        #region ctor
        private readonly DataBaseContext _db;
        public UnitOfWork(DataBaseContext db)
        {
            _db = db;
        }
        #endregion

        private IPostTextRepository _postTextRepository { get; set; }
        public IPostTextRepository PostTextRepository => _postTextRepository ??= new PostTextRepository(_db);
        private IPostTextVisitRepository _postTextVisitRepository { get; set; }
        public IPostTextVisitRepository PostTextVisitRepository => _postTextVisitRepository ??= new PostTextVisitRepository(_db);
        private ILikePostRepository _likePostRepository { get; set; }
        public ILikePostRepository LikePostRepository => _likePostRepository ??= new LikePostRepository(_db);
        private ISavePostRepository _savePostRepository { get; set; }
        public ISavePostRepository SavePostRepository => _savePostRepository ??= new SavePostRepository(_db);
        private IUserRepository _userRepository { get; set; }
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_db);
        private IUserInUserRepository _userInUserRepository { get; set; }
        public IUserInUserRepository UserInUserRepository => _userInUserRepository ??= new UserInUserRepository(_db);
        private IUserAnswerRepository _userAnswerRepository { get; set; }
        public IUserAnswerRepository UserAnswerRepository => _userAnswerRepository ??= new UserAnswerReposiitory(_db);
        private IQuestionsRepository _questionsRepository { get; set; }
        public IQuestionsRepository QuestionsRepository => _questionsRepository ??= new QuestionRepository(_db);
        private IAsnwerRepository _asnwerRepository { get; set; }
        public IAsnwerRepository AsnwerRepository => _asnwerRepository ??= new AsnwerRepository(_db);
        private IGroupRepository _groupRepository { get; set; }
        public IGroupRepository GroupRepository => _groupRepository ??= new GroupsRepository(_db);
        private ICommentRepository _commentRepository { get; set; }
        public ICommentRepository CommentRepository => _commentRepository ??= new CommentRepository(_db);
        private IOffersRepository _offersRepository { get; set; }
        public IOffersRepository OffersRepository => _offersRepository ??= new OffersRepository(_db);

        #region actions

        public void SaveChange()
        {
            _db.SaveChanges();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _db.SaveChangesAsync();
        }

        #endregion

        #region IDisposable Support
        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue) return;
            if (disposing)
            {
                _db.Dispose();
            }

            _disposedValue = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
