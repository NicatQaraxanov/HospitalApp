using DbDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbDll
{
    public interface IAccessDb
    {

        public List<Doctor> getDocs();

        public Doctor getDocsById(int? id);

        public Admin findAdminByUsername(string username);

        public Patient findPatientByUsername(string username);

        public List<DoctorPatients> getDoctorPatients();

        public List<Patient> getPatientsOfDoc(int? id);

        public void addAdmin(Admin obj);

        public void addPatient(Patient obj);

        public void addDoctorPatients(DoctorPatients obj);

        public void addDoc(Doctor obj);

        public void editDoc(Doctor obj);

        public void deleteDoc(Doctor obj);

        public void save();

    }
}
