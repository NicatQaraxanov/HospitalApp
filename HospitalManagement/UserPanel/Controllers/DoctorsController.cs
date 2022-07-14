using Microsoft.AspNetCore.Mvc;
using DbDll.Models;
using DbDll;

namespace UserPanel.Controllers
{
    public class DoctorsController : Controller
    {

        public readonly IAccessDb _access;

        public DoctorsController(IAccessDb access)
        {
            _access = access;
        }

        public static Patient CurrentPatient { get; set; }

        //GET
        public IActionResult Index(Patient? p)
        {
            if(p != null)
                CurrentPatient = p;
            IEnumerable<Doctor> objDcotorList = _access.getDocs();
            return View(objDcotorList);
        }

        public IActionResult Apply(int? id)
        {
            var doctor = _access.getDocsById(id);
            if(_access.getDoctorPatients().FirstOrDefault(dp => dp.PatientId == CurrentPatient.Id && dp.DoctorId == doctor.Id) != null)
            {
                TempData["error"] = "You have already applied for this doctor!!";
                return RedirectToAction("Index", new RouteValueDictionary(CurrentPatient));
            }
            var docPat = new DoctorPatients() { PatientId = CurrentPatient.Id, DoctorId = doctor.Id };
            _access.addDoctorPatients(docPat);
            _access.save();
            return RedirectToAction("Index", new RouteValueDictionary(CurrentPatient));
        }

    }
}
