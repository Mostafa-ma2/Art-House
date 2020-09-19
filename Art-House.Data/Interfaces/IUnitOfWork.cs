using Art_House.Data.Interfaces.Repositories;
using Art_House.Data.Interfaces.Repositories.PostTexts;
using Art_House.Data.Interfaces.Repositories.Questions;
using Art_House.Data.Interfaces.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Art_House.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IPostTextRepository PostTextRepository { get; set; }
        ILikePostRepository LikePostRepository { get; set; }
        ISavePostRepository SavePostRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IUserAnswerRepository UserAnswerRepository { get; set; }
        IUserInUserRepository UserInUserRepository { get; set; }
        IQuestionsRepository QuestionsRepository { get; set; }
        IAsnwerRepository AsnwerRepository { get; set; }
        IGroupRepository GroupRepository { get; set; }
        ICommentRepository CommentRepository { get; set; }
        IOffersRepository OffersRepository { get; set; }
        void SaveChange();
        Task<int> SaveChangeAsync();

    }
}
