using UserPanel.DTOs;
using Microsoft.AspNetCore.Mvc;
using UserPanel.Security;
using DbDll;
using DbDll.Models;

namespace UserPanel.Controllers
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
        public IActionResult Register(UserDto user)
        {
            var dbUser = _access.findAdminByUsername(user.Username);
            if (dbUser == null)
            {
                Hash.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

                var newUser = new Patient() { Username = user.Username, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Age = user.Age, Name = user.Name, Surname = user.Surname };

                _access.addPatient(newUser);

                _access.save();

                return RedirectToAction("Index", "Doctors", new RouteValueDictionary(newUser));
            }
            else
            {
                TempData["error"] = "Username already exists!!";
                return RedirectToAction("Index");
            }
        }
    }
}
