using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Savory.Models;

namespace Savory.Controllers
{
  [Authorize] 
  public class FlavorsController : Controller
  {
    private readonly SavoryContext _db;
     private readonly UserManager<ApplicationUser> _userManager; 


    public FlavorsController(UserManager<ApplicationUser> userManager, SavoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }
   public async Task<ActionResult> Index()
{
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    var userItems = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).ToList();
    return View(userItems);
}

    public ActionResult Create()
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View();
    }

    [HttpPost]
public async Task<ActionResult> Create(Flavor flavor, int TreatId)
{
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    flavor.User = currentUser;
    _db.Flavors.Add(flavor);
    if (TreatId != 0)
    {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
    }
    _db.SaveChanges();
    return RedirectToAction("Index");
}
  

    public ActionResult Details(int id)
   {
     var thisFlavor = _db.Flavors
         .Include(flavor => flavor.Treats)
         .ThenInclude(join => join.Treat)
         .FirstOrDefault(flavor => flavor.FlavorId == id);
     return View(thisFlavor);
   }

    public ActionResult Edit(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "TreatName");
      return View(thisFlavor);
    }

    [HttpPost]
    public ActionResult Edit(Flavor flavor, int TreatId)
    {
      if (TreatId != 0)
      {
        _db.FlavorTreat.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
      }
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      return View(thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavor = _db.Flavors.FirstOrDefault(flavors => flavors.FlavorId == id);
      _db.Flavors.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }



  }
}