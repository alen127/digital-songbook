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
        var chords = _dbContext.Chords.Where(c => c.UserId == UserID);
        return View(chords.ToList());
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

        var chord = new Chord()
            { Name = model.Name, Strings = model.Frets, Fingering = model.Fingers, UserId = model.UserId };


        _dbContext.Chords.Add(chord);
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var chord = _dbContext.Chords.Find(id);
        if (chord == null) return NotFound();
        var model = new ChordCreateEditModel()
        {
            Name = chord.Name, UserId = chord.UserId,
            E2Fret = chord.Strings[0], AFret = chord.Strings[1], DFret = chord.Strings[2], GFret = chord.Strings[3],
            BFret = chord.Strings[4], E4Fret = chord.Strings[5],
            E2Finger = chord.Fingering[0], AFinger = chord.Fingering[1], DFinger = chord.Fingering[2],
            GFinger = chord.Fingering[3], BFinger = chord.Fingering[4], E4Finger = chord.Fingering[5]
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
            return View(model);
        }

        var chord = _dbContext.Chords.Find(id);
        if (chord == null) return NotFound();

        chord.Name = model.Name;
        chord.Strings[0] = model.E2Fret;
        chord.Strings[1] = model.AFret;
        chord.Strings[2] = model.DFret;
        chord.Strings[3] = model.GFret;
        chord.Strings[4] = model.BFret;
        chord.Strings[5] = model.E4Fret;

        chord.Fingering[0] = model.E2Finger;
        chord.Fingering[1] = model.AFinger;
        chord.Fingering[2] = model.DFinger;
        chord.Fingering[3] = model.GFinger;
        chord.Fingering[4] = model.BFinger;
        chord.Fingering[5] = model.E4Finger;

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
        var selectItems = new List<SelectListItem>()
        {
            new() { Value = "-1", Text = "x - Muted", Selected = true }
        };
        for (var i = 0; i <= 24; i++)
        {
            selectItems.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
        }

        ViewBag.FretOptions = selectItems;
    }

    private void FillFingerDropdown()
    {
        var selectItems = new List<SelectListItem>()
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