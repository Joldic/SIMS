using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sekretar.Model;
using sekretar.Service;

namespace sekretar.Controller
{
    public class PatientController
    {
        private readonly PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }

        public Patient CreateNewPatient(Patient patient)
        {
            return _service.CreateNewPatient(patient);
        }

        public Patient ReadPatient(uint id)
        {
            return _service.ReadPatient(id);
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _service.UpdatePatient(patient);
        }

        public Boolean DeletePatient(uint id)
        {
            return _service.DeletePatient(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _service.GetAll();
        }
    }
}
