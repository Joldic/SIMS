using System;
using Model;
using System.Collections.Generic;
using Repository;

namespace Service
{
   public class ApointmentService
   {

        private readonly ApointmentRepository _appointmentRepo;

        public ApointmentService(ApointmentRepository appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public Appointment CreateNewAppointment(Appointment appointment)
        {
            var ret = _appointmentRepo.AddAppointment(appointment);
            return ret;
        }

        public Appointment ReadAppointment(uint id)
        {
            var ret = _appointmentRepo.GetAppointment(id);
            return ret;
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var ret = _appointmentRepo.UpdateAppointment(appointment);
            return ret;
        }

        public Boolean DeleteAppointment(uint id)
        {
            return _appointmentRepo.RemoveAppointment(id);
        }

        internal List<Appointment> GetAll()
        {
            var appointments = _appointmentRepo.GetAll();
            return appointments;
        }














    }
}