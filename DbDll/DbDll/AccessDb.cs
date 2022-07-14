using DbDll.Data;
using DbDll.Models;
using Microsoft.EntityFrameworkCore;

namespace DbDll
{
    public class AccessDb : IAccessDb
    {

        public readonly ApplicationDbContext _db;

        public AccessDb()
        {
            _db = new ApplicationDbContext();
        }

        public List<Doctor> getDocs()
        {
            var docs = _db.Doctors.ToList();
            docs.ForEach(d => d.DoctorPatients = _db.DoctorPatients.Where(dp => dp.DoctorId == d.Id).ToList());
            return docs;
        }

        public Doctor getDocsById(int? id)
        {
            return _db.Doctors.FirstOrDefault(d => d.Id == id);
        }

        public Admin findAdminByUsername(string username)
        {
            return _db.Admins.FirstOrDefault(a => a.Username == username);
        }

        public Patient findPatientByUsername(string username)
        {
            return _db.Patients.FirstOrDefault(p => p.Username == username);
        }

        public List<DoctorPatients> getDoctorPatients()
        {
            return _db.DoctorPatients.ToList();
        }

        public List<Patient> getPatientsOfDoc(int? id)
        {
            var docP = _db.DoctorPatients.Where(dp => dp.DoctorId == id).ToList();
            var patients = new List<Patient>();
            foreach (var d in docP)
            {
                patients.Add(_db.Patients.FirstOrDefault(p => p.Id == d.PatientId));
            }

            return patients;
        }

        public void addAdmin(Admin obj)
        {
            _db.Admins.Add(obj);
        }

        public void addPatient(Patient obj)
        {
            _db.Patients.Add(obj);
        }

        public void addDoctorPatients(DoctorPatients obj)
        {
            _db.DoctorPatients.Add(obj);
        }

        public void addDoc(Doctor obj)
        {
            _db.Doctors.Add(obj);
        }

        public void editDoc(Doctor obj)
        {
            _db.Doctors.Update(obj);
        }

        public void deleteDoc(Doctor obj)
        {
            _db.Doctors.Remove(obj);
        }

        public void save()
        {
            _db.SaveChanges();
        }



    }
}