using Microsoft.AspNetCore.Mvc;
using Savory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Savory.Controllers
{
  public class TreatsController : Controller
  {
    private readonly SavoryContext _db;

    public TreatsController(SavoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Treat> model = _db.Treats.ToList();
      return View(model);
    }

      public ActionResult Create()
   {
     return View();
   }

   [HttpPost]
   public ActionResult Create(Treat treat)
   {
     _db.Treats.Add(treat);
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


  }
}