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
      public Patient CreateNewPatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Patient ReadPatient(uint idPatient)
      {
         throw new NotImplementedException();
      }
      
      public Patient UpdatePatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeletePatient(uint idPatient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Patient> GetAll()
      {
         throw new NotImplementedException();
      }
      
      public PatientService patientService;
   
   }
}