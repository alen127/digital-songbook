using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Web.Models;

namespace Web.Controllers;

[Authorize]
public class ArtistController(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
    : BaseController(_userManager)
{
    public IActionResult Index()
    {
        var artists = _dbContext.Artists.Where(artist => artist.UserId == UserID).ToList();
        var model = artists.Select(artist => new ArtistViewModel()
            { Id = artist.Id, Name = artist.Name, ImageUrl = artist.ImageUrl }).ToList();
        return View(model);
    }

    public IActionResult Create()
    {
        // GET
        // Display form for adding artist
        return View(new ArtistCreateEditModel());
    }

    [HttpPost]
    public IActionResult Create(ArtistCreateEditModel model)
    {
        if (!ModelState.IsValid)
        {
            // Validation failed, return the form back to the user
            return View(model);
        }

        // Validation passed, proceed with processing the form submission
        _dbContext.Artists.Add(new Artist()
        {
            Name = model.Name, UserId = model.UserId,
            ImageUrl = model.ImageUrl
        });
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var artist = _dbContext.Artists.Include(a => a.Songs).ThenInclude(s => s.Sections)
            .ThenInclude(songSection => songSection.ChordSongSections).SingleOrDefault(a => a.Id == id);
        if (artist == null)
        {
            return NotFound();
        }

        foreach (var song in artist.Songs)
        {
            foreach (var songSection in song.Sections)
            {
                _dbContext.ChordSongSections.RemoveRange(songSection.ChordSongSections);
            }
        }

        _dbContext.Artists.Remove(artist);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var artist = _dbContext.Artists.Find(id);
        if (artist == null) return NotFound();
        return View(new ArtistCreateEditModel()
            { Name = artist.Name, ImageUrl = artist.ImageUrl, UserId = artist.UserId });
    }

    [HttpPost]
    public IActionResult Edit(int id, ArtistCreateEditModel model)
    {
        var artist = _dbContext.Artists.Find(id);

        if (artist == null)
            return NotFound();
        if (!ModelState.IsValid)
        {
            // Validation failed, return the form back to the user
            return View(new ArtistCreateEditModel()
                { Name = artist.Name, ImageUrl = artist.ImageUrl, UserId = artist.UserId });
        }

        // Validation passed, proceed with processing the form submission
        _dbContext.Update(artist);
        artist.Name = model.Name;
        artist.ImageUrl = model.ImageUrl;
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}