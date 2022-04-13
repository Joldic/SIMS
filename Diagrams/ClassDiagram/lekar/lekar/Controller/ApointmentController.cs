using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
   public class ApointmentController
   {
        private readonly ApointmentService _service;
        public ApointmentController(ApointmentService service)
        {
            _service = service;
        }

        public Appointment CreateNewAppointment(Appointment appointment)
        {
            return _service.CreateNewAppointment(appointment);
        }

        public Appointment ReadAppointment(uint id)
        {
            return _service.ReadAppointment(id);
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            return _service.UpdateAppointment(appointment);
        }

        public Boolean DeleteAppointment(uint id)
        {
            return _service.DeleteAppointment(id);
        }

        public List<Appointment> GetAll()
        {
            return _service.GetAll();
        }
    }
}