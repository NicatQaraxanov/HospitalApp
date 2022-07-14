using AdminPanel.DTOs;
using Microsoft.AspNetCore.Mvc;
using AdminPanel.Security;
using DbDll;
using DbDll.Models;

namespace AdminPanel.Controllers
{
    public class RegisterController : Controller
    {

        public readonly IAccessDb _access;


        public RegisterController(IAccessDb access)
        {
            _access = access;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AdminDto admin)
        {
            var dbAdmin = _access.findAdminByUsername(admin.Username);
            if (dbAdmin == null)
            {
                Hash.CreatePasswordHash(admin.Password, out byte[] passwordHash, out byte[] passwordSalt);

                _access.addAdmin(new Admin() { Username = admin.Username, PasswordHash = passwordHash, PasswordSalt = passwordSalt });

                _access.save();

                return RedirectToAction("Index", "Doctors");
            }
            else
            {
                TempData["error"] = "Username already exists!!";
                return RedirectToAction("Index");
            }
        }
    }
}
