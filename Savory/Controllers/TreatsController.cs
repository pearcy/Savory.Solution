using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Savory.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Savory.Controllers
{

  [Authorize]
  public class TreatsController : Controller
  {
    private readonly SavoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager; 

      public TreatsController(UserManager<ApplicationUser> userManager, SavoryContext db)
      {
        _userManager = userManager;
        _db = db;
      }
    // public TreatsController(SavoryContext db)
    // {
    //   _db = db;
    // }

      public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userTreats);
    }

      public ActionResult Create()
   {
     return View();
   }

  //  [HttpPost]
  //  public ActionResult Create(Treat treat)
  //  {
  //    _db.Treats.Add(treat);
  //    _db.SaveChanges();
  //    return RedirectToAction("Index");
  //  }

   [HttpPost]
public async Task<ActionResult> Create(Treat treat, int FlavorId)
{
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    treat.User = currentUser;
    _db.Treats.Add(treat);
    if (FlavorId != 0)
    {
        _db.FlavorTreat.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = treat.TreatId });
    }
    _db.SaveChanges();
    return RedirectToAction("Index");
}

public ActionResult Details(int id)
  {
    var thisTreat = _db.Treats
        .Include(treat => treat.Flavors)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
    return View(thisTreat);
  }

public ActionResult Edit(int id)
{
  var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
  return View(thisTreat);
}

[HttpPost]
public ActionResult Edit(Treat treat)
{
  _db.Entry(treat).State = EntityState.Modified;
  _db.SaveChanges();
  return RedirectToAction("Index");
}

public ActionResult Delete(int id)
   {
     var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
     return View(thisTreat);
   }

   [HttpPost, ActionName("Delete")]
   public ActionResult DeleteConfirmed(int id)
   {
     var thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
     _db.Treats.Remove(thisTreat);
     _db.SaveChanges();
     return RedirectToAction("Index");
   }


  }
}