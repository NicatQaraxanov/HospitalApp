using UserPanel.DTOs;
using UserPanel.Security;
using Microsoft.AspNetCore.Mvc;
using DbDll.Models;
using DbDll;

namespace UserPanel.Controllers
{
    public class LoginController : Controller
    {

        public readonly IAccessDb _access;

        public LoginController(IAccessDb access)
        {
            _access = access;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(UserDto user)
        {
            var dbUser = _access.findPatientByUsername(user.Username);
            if (dbUser == null)
            {
                TempData["error"] = "Wrong username or password!!";
                return RedirectToAction("Index");
            }

            if (!Hash.VerifyPasswordHash(user.Password, dbUser.PasswordHash, dbUser.PasswordSalt))
            {
                TempData["error"] = "Wrong username or password!!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Doctors", new RouteValueDictionary(dbUser));
        }
    }
}
