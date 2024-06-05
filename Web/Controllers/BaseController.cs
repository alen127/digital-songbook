using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Web.Controllers;

public class BaseController(UserManager<ApplicationUser> _userManager) : Controller
{
    protected string UserID => _userManager.GetUserId(User);

    protected async Task<ApplicationUser> GetCurrentUser()
    {
        var user = await _userManager.Users.Include(u => u.Artists).FirstOrDefaultAsync(u => u.Id == UserID);
        return user;
    }
}