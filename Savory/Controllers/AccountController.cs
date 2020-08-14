using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Savory.Models;
using System.Threading.Tasks;
using Savory.ViewModels;

namespace Savory.Controllers
{
    public class AccountController : Controller
    {
        private readonly SavoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SavoryContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }


  }
}