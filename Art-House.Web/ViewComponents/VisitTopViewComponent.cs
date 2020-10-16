using Art_House.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_House.Web.ViewComponents
{
    public class VisitTopViewComponent:ViewComponent
    {
        //پربازدید ها
        #region
        private readonly IUnitOfWork _db;
        public VisitTopViewComponent(IUnitOfWork db)
        {
            _db = db;
        }
        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Post =await _db.PostTextRepository.GetAllAsync();
          var posts= Post.OrderByDescending(p => p.Visit).Take(4);

            return View("VisitTop", posts);
        }
    }
}
