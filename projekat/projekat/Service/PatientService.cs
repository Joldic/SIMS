// File:    PatientService.cs
// Author:  3500x
// Created: 12 April 2022 19:00:06
// Purpose: Definition of Class PatientService

using System;
using Repository;

using System.Collections.Generic;
using Model;
namespace Service
{
   public class PatientService
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
      
      public PatientRepository patientRepository;
   
   }
}