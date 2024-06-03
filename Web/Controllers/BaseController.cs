using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Web.Controllers;

public class BaseController(UserManager<ApplicationUser> _userManager) : Controller
{
    protected string UserID => _userManager.GetUserId(User);
}