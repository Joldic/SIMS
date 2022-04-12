using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sekretar.Model;
using sekretar.Repository;

namespace sekretar.Service
{
    public class PatientService
    {
        private readonly PatientRepository _patientRepo;

        public PatientService(PatientRepository patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public Patient CreateNewPatient(Patient patient)
        {
            var ret = _patientRepo.AddPatient(patient);
            return ret;
        }

        public Patient ReadPatient(uint id)
        {
            var ret = _patientRepo.GetPatient(id);
            return ret;
        }

        public Patient UpdatePatient(Patient patient)
        {
            var ret = _patientRepo.UpdatePatient(patient);
            return ret;
        }

        public Boolean DeletePatient(uint id)
        {
            return _patientRepo.RemovePatient(id);
        }

        internal IEnumerable<Patient> GetAll()
        {
            var patients = _patientRepo.GetAll();
            return patients;
        }


    }
}
