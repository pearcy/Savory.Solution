  using Microsoft.AspNetCore.Mvc;
    using Savory.Models;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using System.Security.Claims;
    using System;


    namespace Savory.Controllers
    {
      [Authorize]
      public class BakersController : Controller
      {
        private readonly SavoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BakersController(UserManager<ApplicationUser> userManager, SavoryContext db)
        {
          _userManager = userManager;
          _db = db;
        }

        public async Task<ActionResult> Index(string searchBaker)
        {
          if(!string.IsNullOrEmpty(searchBaker))
          {
            var searchBakers = _db.Bakers.Where(bakers => bakers.Name.Contains(searchBaker));                    
            return View(searchBakers);
          }
          
          return View(_db.Bakers.ToList());
        }

        [Authorize]
        public ActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Baker baker)
        {
          var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          var currentUser = await _userManager.FindByIdAsync(userId);
          baker.User = currentUser;
          _db.Bakers.Add(baker);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }

    }
  }