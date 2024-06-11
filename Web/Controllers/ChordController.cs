using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Web.Models;

namespace Web.Controllers;

[Authorize]
public class ChordController(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
    : BaseController(_userManager)
{
    public IActionResult Index()
    {
        var chords = _dbContext.Chords.Where(c => c.UserId == UserID).ToList();
        var model = chords.Select(chord => new ChordViewModel
            { Id = chord.Id, Name = chord.Name, Frets = chord.Frets, Fingers = chord.Fingers }).ToList();
        return View(model);
    }

    public IActionResult Create()
    {
        FillFretDropdown();
        FillFingerDropdown();
        return View();
    }

    [HttpPost]
    public IActionResult Create(ChordCreateEditModel model)
    {
        if (!ModelState.IsValid)
        {
            FillFretDropdown();
            FillFingerDropdown();
            return View(model);
        }

        var chord = new Chord
            { Name = model.Name, Frets = model.Frets, Fingers = model.Fingers, UserId = model.UserId };


        _dbContext.Chords.Add(chord);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var chord = _dbContext.Chords.Find(id);
        if (chord == null) return NotFound();
        var model = new ChordCreateEditModel
        {
            Name = chord.Name, UserId = chord.UserId,
            E2Fret = chord.Frets[0], AFret = chord.Frets[1], DFret = chord.Frets[2], GFret = chord.Frets[3],
            BFret = chord.Frets[4], E4Fret = chord.Frets[5],
            E2Finger = chord.Fingers[0], AFinger = chord.Fingers[1], DFinger = chord.Fingers[2],
            GFinger = chord.Fingers[3], BFinger = chord.Fingers[4], E4Finger = chord.Fingers[5]
        };
        FillFingerDropdown();
        FillFretDropdown();
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, ChordCreateEditModel model)
    {
        if (!ModelState.IsValid)
        {
            FillFingerDropdown();
            FillFretDropdown();
            return View(model);
        }

        var chord = _dbContext.Chords.Find(id);
        if (chord == null) return NotFound();

        chord.Name = model.Name;
        chord.Frets[0] = model.E2Fret;
        chord.Frets[1] = model.AFret;
        chord.Frets[2] = model.DFret;
        chord.Frets[3] = model.GFret;
        chord.Frets[4] = model.BFret;
        chord.Frets[5] = model.E4Fret;

        chord.Fingers[0] = model.E2Finger;
        chord.Fingers[1] = model.AFinger;
        chord.Fingers[2] = model.DFinger;
        chord.Fingers[3] = model.GFinger;
        chord.Fingers[4] = model.BFinger;
        chord.Fingers[5] = model.E4Finger;

        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var chord = _dbContext.Chords.Find(id);
        if (chord == null) return NotFound();
        _dbContext.Chords.Remove(chord);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }


    private void FillFretDropdown()
    {
        var selectItems = new List<SelectListItem>
        {
            new() { Value = "-1", Text = "x - Muted", Selected = true }
        };
        for (var i = 0; i <= 24; i++) selectItems.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });

        ViewBag.FretOptions = selectItems;
    }

    private void FillFingerDropdown()
    {
        var selectItems = new List<SelectListItem>
        {
            new() { Value = "-1", Text = "No finger", Selected = true },
            new() { Value = "0", Text = "T - Thumb" },
            new() { Value = "1", Text = "1 - Index" },
            new() { Value = "2", Text = "2 - Middle" },
            new() { Value = "3", Text = "3 - Ring" },
            new() { Value = "4", Text = "4 - Pinky" }
        };

        ViewBag.FingerOptions = selectItems;
    }
}