// File:    PregledRepository.cs
// Author:  joldic
// Created: 30 March 2022 18:43:52
// Purpose: Definition of Class PregledRepository

using System;
using Repository;

using System.Collections.Generic;
using Model;
namespace Service
{
   public class AppointmentService
   {
        private readonly AppointmentRepository _repo;

        public AppointmentService(AppointmentRepository repo)
        {
            _repo = repo;
        }
        public Appointment CreateNewAppointment(Appointment appointment)
        {
            return _repo.CreateNewAppointment(appointment);
        }

        public Appointment CreateNewOperation(Appointment appointment)
        {
            return _repo.CreateNewOperation(appointment);
        }

        public Boolean DeleteApointment(uint id)
        {
            return _repo.DeleteApointment(id);
        }

        public Boolean DeleteOperation(uint id)
        {
            return _repo.DeleteOperation(id);
        }

        public Appointment UpdateApointment(Appointment apointment)
        {
            return _repo.UpdateApointment(apointment);
        }

        public Appointment UpdateOperation(Appointment appointment)
        {
            return _repo.UpdateOperation(appointment);
        }

        public Appointment GetApointment(uint id)
        {
            return _repo.GetApointment(id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Appointment> GetAllOperations()
        {
            return _repo.GetAllOperations();
        }

        public AppointmentRepository apointmentRepository;
   
   }
}