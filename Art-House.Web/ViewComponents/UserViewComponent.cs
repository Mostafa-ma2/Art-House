using Art_House.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Art_House.Web.ViewComponents
{
    public class UserViewComponent : ViewComponent
    {
        #region ctor
        private readonly UserManager<User> _userManager;
        public UserViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;

        }
        #endregion
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var getUser =await _userManager.FindByIdAsync(id);
            return (IViewComponentResult)View("User", getUser);
        }
    }
}
