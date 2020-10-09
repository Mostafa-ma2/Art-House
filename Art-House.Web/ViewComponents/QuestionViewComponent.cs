using Art_House.Common.Extensions;
using Art_House.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_House.Web.ViewComponents
{
    public class QuestionViewComponent:ViewComponent
    {
        //گرفتن گروه ها
        #region
        private readonly IUnitOfWork _db;
        public QuestionViewComponent(IUnitOfWork db)
        {
            _db = db;
        }
        #endregion

        //Get
        [HttpGet]
        public IViewComponentResult Invoke()
        {
            var date = DateTime.Now.ToPersianDateString();
            var question =  _db.QuestionsRepository.Where(p=>p.StartThePoll <= Convert.ToDateTime(date)&&p.EndThePoll>= Convert.ToDateTime(date)).Take(1).ToList();
            return (IViewComponentResult)View("Question", question);
        }
    }
}
