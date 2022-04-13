using System;
using Model;
using System.Collections.Generic;
using Service;

namespace Controller
{
   public class PatientControler
   {
        private readonly PatientService _service;

        public PatientControler(PatientService service)
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