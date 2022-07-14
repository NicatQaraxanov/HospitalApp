
using AdminPanel.DTOs;
using AdminPanel.Security;
using Microsoft.AspNetCore.Mvc;
using DbDll.Models;
using DbDll;

namespace AdminPanel.Controllers
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

        public IActionResult Login(AdminDto admin)
        {
            var dbAdmin = _access.findAdminByUsername(admin.Username);
            if (dbAdmin == null)
            {
                TempData["error"] = "Wrong username or password!!";
                return RedirectToAction("Index");
            }

            if (!Hash.VerifyPasswordHash(admin.Password, dbAdmin.PasswordHash, dbAdmin.PasswordSalt))
            {
                TempData["error"] = "Wrong username or password!!";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index", "Doctors");
        }
    }
}
