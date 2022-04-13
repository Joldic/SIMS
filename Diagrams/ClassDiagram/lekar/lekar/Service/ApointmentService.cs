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
            var apo = _appointmentRepo.AddAppointment(appointment);
            return apo;
        }

        public Appointment ReadAppointment(uint id)
        {
            var apo = _appointmentRepo.GetAppointment(id);
            return apo;
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var apo = _appointmentRepo.UpdateAppointment(appointment);
            return apo;
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