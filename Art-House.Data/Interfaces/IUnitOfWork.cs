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
        IPostTextRepository PostTextRepository { get;}
        ILikePostRepository LikePostRepository { get;}
        ISavePostRepository SavePostRepository { get;}
        IPostTextVisitRepository PostTextVisitRepository { get; }

        IUserRepository UserRepository { get; }
        IUserAnswerRepository UserAnswerRepository { get; }
        IUserInUserRepository UserInUserRepository { get;  }
        IQuestionsRepository QuestionsRepository { get;  }
        IBtnQuestionRepository BtnQuestionRepository { get; }
        IGroupRepository GroupRepository { get;  }
        ICommentRepository CommentRepository { get;  }
        IOffersRepository OffersRepository { get; }
        void SaveChange();
        Task<int> SaveChangeAsync();
    }
}
