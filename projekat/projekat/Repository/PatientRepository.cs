// File:    PatientRepository.cs
// Author:  3500x
// Created: 12 April 2022 19:14:48
// Purpose: Definition of Class PatientRepository

using System;
using System.Collections.Generic;
using Model;

namespace Repository
{
   public class PatientRepository
   {
      private String fileName;
      
      public Patient AddPatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Patient GetPatient(uint idPatient)
      {
         throw new NotImplementedException();
      }
      
      public Patient UpdatePatient(Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Boolean RemovePatient(uint idPatient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Patient> GetAll()
      {
         throw new NotImplementedException();
      }
   
   }
}