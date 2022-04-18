// File:    Appointment.cs
// Author:  User
// Created: Monday, April 11, 2022 4:25:39 PM
// Purpose: Definition of Class Appointment

using System;

namespace Model
{
   public class Appointment
   {
      private uint idAppointment;
      private DateTime startAppointment;
      private DateTime endAppointment;
      
      public Doctor doctor;
      public Patient patient;
      public Anamnesis anamnesis;
   
   }
}