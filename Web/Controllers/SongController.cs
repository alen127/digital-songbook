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
        var song = _dbContext.Songs.Include(song => song.Artist).Include(song => song.Sections)
            .ThenInclude(songSection => songSection.Chords).Include(song => song.Sections)
            .ThenInclude(songSection => songSection.ChordSongSections)
            .SingleOrDefault(song => song.Id == id);
        if (song == null) return NotFound();
        var model = new SongViewModel()
        {
            Id = song.Id,
            Name = song.Name,
            Bpm = song.Bpm,
            Artist = new ArtistViewModel()
            {
                Name = song.Artist.Name,
                Id = song.ArtistId,
                ImageUrl = song.Artist.ImageUrl
            },
            StrummingPattern = new StrummingViewModel() { StrummingPattern = song.StrummingPattern },
            Sections = song.Sections.Select(section => new SongSectionViewModel
            {
                Id = section.Id,
                Name = section.Name,
                Lyrics = section.Lyrics,
                StrummingPattern = new StrummingViewModel { StrummingPattern = section.StrummingPattern },
                Chords = section.Chords.Select(chord => new ChordViewModel
                    { Id = chord.Id, Name = chord.Name, Frets = chord.Frets, Fingers = chord.Fingers }).ToList(),
                Position = section.Position, ChordSongSections = section.ChordSongSections.ToList()
            }).ToList()
        };
        return View(model);
    }

    public IActionResult CreateSection(int songId, SongSectionFormModel model)
    {
        model.SongId = songId;

        FillChordDropdown();
        return View(model);
    }

    [HttpPost]
    public IActionResult CreateSection(SongSectionFormModel model)
    {
        if (!ModelState.IsValid)
        {
            FillChordDropdown();
            return View(model);
        }

        var songSection = new SongSection()
        {
            Name = model.Name,
            SongId = model.SongId,
            Lyrics = model.Lyrics,
            StrummingPattern = model.StrummingPatternArray, 
            Position = model.Position,
        };
        
        _dbContext.Sections.Add(songSection);
        _dbContext.SaveChanges();
        foreach (var chordId in model.ChordIds)
        {
            var chordSongSection = new ChordSongSection()
            {
                SongSectionId = songSection.Id,
                ChordId = chordId
            };

            _dbContext.ChordSongSections.Add(chordSongSection);
        }

        _dbContext.SaveChanges();

        // Redirect to song page using model.SongId
        return RedirectToAction("Song", new { id = model.SongId });
    }

    public IActionResult EditSection(int id)
    {
        var section = _dbContext.Sections.Include(section => section.Chords)
            .SingleOrDefault(section => section.Id == id);
        if (section == null) return NotFound();

        var model = new SongSectionFormModel()
        {
            Name = section.Name,
            SongId = section.SongId,
            Lyrics = section.Lyrics,
            Position = section.Position,
            StrummingPattern = SongSectionFormModel.ConvertBoolArrayToStrummingPattern(section.StrummingPattern),
            ChordIds = section.Chords.Select(chord => chord.Id).ToList()
        };

        FillChordDropdown();
        return View(model);
    }

    public IActionResult DeleteSection(int id)
    {
        var songSection = _dbContext.Sections.Include(s => s.Chords)
            .Include(songSection => songSection.ChordSongSections).FirstOrDefault(s => s.Id == id);
        if (songSection == null) return NotFound();

        var songId = songSection.SongId;

        // Remove the ChordSongSection entities that reference the SongSection
        _dbContext.ChordSongSections.RemoveRange(songSection.ChordSongSections);

        _dbContext.Sections.Remove(songSection);
        _dbContext.SaveChanges();
        return RedirectToAction("Song", new { id=songId });
    }


    private void FillChordDropdown()
    {
        var chords = _dbContext.Chords.Where(chord => chord.UserId == UserID).ToList();
        var selectItems =
            chords.Select(chord => new SelectListItem() { Text = chord.Name, Value = chord.Id.ToString() });
        ViewBag.ChordOptions = selectItems;
    }

    private void FillArtistDropdown()
    {
        var artists = _dbContext.Artists.Where(artist => artist.UserId == UserID).ToList();
        var selectItems = artists
            .Select(artist => new SelectListItem() { Text = artist.Name, Value = artist.Id.ToString() }).ToList();

        ViewBag.ArtistOptions = selectItems;
    }
}