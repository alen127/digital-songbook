using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using Web.Models;

namespace Web.Controllers;

[Authorize]
public class SongController(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
    : BaseController(_userManager)
{
    // GET
    public IActionResult Index()
    {
        var songs = _dbContext.Songs.Include(song => song.Artist).Where(song => song.UserId == UserID).ToList();
        var model = songs.Select(song => new SongViewModel()
        {
            Id = song.Id,
            Artist = new ArtistViewModel()
                { Name = song.Artist.Name, Id = song.ArtistId, ImageUrl = song.Artist.ImageUrl },
            Bpm = song.Bpm, Name = song.Name,
            StrummingPattern = new StrummingViewModel() { StrummingPattern = song.StrummingPattern }
        }).ToList();
        return View(model);
    }

    public IActionResult Create()
    {
        FillArtistDropdown();
        return View();
    }

    [HttpPost]
    public IActionResult Create(SongCreateEditModel model)
    {
        if (!ModelState.IsValid)
        {
            FillArtistDropdown();
            return View(model);
        }

        var song = new Song()
        {
            Name = model.Name, ArtistId = model.ArtistId, StrummingPattern = model.StrummingPatternArray,
            UserId = model.UserId, Bpm = model.Bpm
        };

        _dbContext.Songs.Add(song);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var song = _dbContext.Songs.Find(id);
        if (song == null) return NotFound();
        var model = new SongCreateEditModel()
        {
            Name = song.Name, ArtistId = song.ArtistId, Bpm = song.Bpm, UserId = song.UserId,
            StrummingPattern = SongCreateEditModel.ConvertBoolArrayToStrummingPattern(song.StrummingPattern)
        };
        FillArtistDropdown();
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, SongCreateEditModel model)
    {
        if (!ModelState.IsValid)
        {
            FillArtistDropdown();
            return View(model);
        }

        var song = _dbContext.Songs.Find(id);
        if (song == null) return NotFound();

        song.Name = model.Name;
        song.ArtistId = model.ArtistId;
        song.StrummingPattern = model.StrummingPatternArray;
        song.Bpm = model.Bpm;
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var song = _dbContext.Songs.Find(id);
        if (song == null) return NotFound();

        _dbContext.Songs.Remove(song);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Song(int id)
    {
        var song = _dbContext.Songs.Include(song => song.Artist).SingleOrDefault(song => song.Id == id);
        if (song == null) return NotFound();
        var model = new SongViewModel()
        {
            Id = song.Id,
            Artist = new ArtistViewModel()
                { Name = song.Artist.Name, Id = song.ArtistId, ImageUrl = song.Artist.ImageUrl },
            Bpm = song.Bpm, Name = song.Name,
            StrummingPattern = new StrummingViewModel() { StrummingPattern = song.StrummingPattern }
        };
        return View(model);
    }

    private void FillArtistDropdown()
    {
        var artists = _dbContext.Artists.Where(artist => artist.UserId == UserID).ToList();
        var selectItems = artists
            .Select(artist => new SelectListItem() { Text = artist.Name, Value = artist.Id.ToString() }).ToList();

        ViewBag.ArtistOptions = selectItems;
    }
}