using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Web.Controllers;

public class ArtistController(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager) : BaseController(_userManager)
{

    public IActionResult Index()
    {
        var artists = _dbContext.Artists.Where(artist => artist.UserId == UserID);
        var list = artists.ToList();
        return View(list);
    }
}