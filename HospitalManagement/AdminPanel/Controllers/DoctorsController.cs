
using Microsoft.AspNetCore.Mvc;
using DbDll.Models;
using DbDll;

namespace AdminPanel.Controllers
{
    public class DoctorsController : Controller
    {

        public readonly IAccessDb _access;

        public DoctorsController(IAccessDb access)
        {
            _access = access;
        }

        public IActionResult Index()
        {
            IEnumerable<Doctor> objDcotorList = _access.getDocs();
            return View(objDcotorList);
        }

        //GET
        public IActionResult Patients(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var patients = _access.getPatientsOfDoc(id);

            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Doctor obj)
        {
            if (ModelState.IsValid)
            {
                _access.addDoc(obj);
                _access.save();
                TempData["success"] = "Doctor added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var doctorFromDb = _access.getDocsById(id);

            if (doctorFromDb == null)
            {
                return NotFound();
            }

            return View(doctorFromDb);
        }

        //POST
        [HttpPost]
        public IActionResult Edit(Doctor obj)
        {
            if (ModelState.IsValid)
            {
                _access.editDoc(obj);
                _access.save();
                TempData["success"] = "Doctor updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _access.getDocsById(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _access.getDocsById(id);
            if (obj == null)
            {
                return NotFound();
            }

            _access.deleteDoc(obj);
            _access.save();
            TempData["success"] = "Doctor deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
