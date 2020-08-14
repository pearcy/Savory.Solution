using Microsoft.AspNetCore.Mvc;
using Savory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Savory.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly SavoryContext _db;

    public FlavorsController(SavoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    

  }
}