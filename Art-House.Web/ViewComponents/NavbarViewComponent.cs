using Art_House.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art_House.Web.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        //گرفتن گروه ها
        #region
        private readonly IUnitOfWork _db;
        public NavbarViewComponent(IUnitOfWork db)
        {
            _db = db;
        }
        #endregion

        //Get
        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var GetGroup = (await _db.GroupRepository.GetAllAsync());
            return View("Navbar", GetGroup);
        }
    }
}
