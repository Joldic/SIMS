// File:    PregledRepository.cs
// Author:  joldic
// Created: 30 March 2022 18:43:52
// Purpose: Definition of Class PregledRepository

using System;
using System.Collections.Generic;
using Model;
using Service;
namespace Controller
{
   public class AppointmentController
   {
        private readonly AppointmentService _service;

        public AppointmentController(AppointmentService service)
        {
            _service = service;
        }
        public Appointment CreateNewAppointment(Appointment appointment)
        {
            return _service.CreateNewAppointment(appointment);
        }

        public Appointment CreateNewOperation(Appointment appointment)
        {
            return _service.CreateNewOperation(appointment);
        }
      
        public Boolean DeleteApointment(uint id)
        {
            return _service.DeleteApointment(id);
        }

        public Boolean DeleteOperation(uint id)
        {
            return _service.DeleteOperation(id);
        }
      
        public Model.Appointment UpdateApointment(Appointment appointment)
        {
            return _service.UpdateApointment(appointment);
        }

        public Appointment UpdateOperation(Appointment appointment)
        {
            return _service.UpdateOperation(appointment);
        }


        public Model.Appointment GetApointment(uint id)
        {
            return _service.GetApointment(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _service.GetAll();
        }

        public IEnumerable<Appointment> GetAllOperations()
        {
            return _service.GetAllOperations();
        }

        
   
   }
}