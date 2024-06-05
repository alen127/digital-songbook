using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class SongController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}