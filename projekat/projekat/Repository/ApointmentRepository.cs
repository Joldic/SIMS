// File:    PregledRepository.cs
// Author:  joldic
// Created: 30 March 2022 18:43:52
// Purpose: Definition of Class PregledRepository

using System;
using System.Collections.Generic;
using Model;

namespace Repository
{
   public class ApointmentRepository
   {
      private String fileName;
      
      public Model.Appointment SetNewApointment(Doctor doctor, Patient patient, Room room, Model.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteApointment(uint apointmID)
      {
         throw new NotImplementedException();
      }
      
      public Model.Appointment UpdateApointment(Model.Doctor doctor, Model.Patient patient, Model.Room room, Model.Appointment apointment)
      {
         throw new NotImplementedException();
      }
      
      public Model.Appointment GetApointment(uint apointmID)
      {
         throw new NotImplementedException();
      }
      
      public List<Appointment> GetAllApointments()
      {
         throw new NotImplementedException();
      }
   
   }
}