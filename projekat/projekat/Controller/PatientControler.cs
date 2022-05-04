// File:    PatientControler.cs
// Author:  3500x
// Created: 12 April 2022 19:20:07
// Purpose: Definition of Class PatientControler

using System;
using System.Collections.Generic;
using Model;
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

       public Patient FindPatientByUsername(string username)
        {
            return _service.FindPatientByUsername(username);
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