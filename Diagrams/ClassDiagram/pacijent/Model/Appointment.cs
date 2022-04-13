using System;

namespace Model
{
   public class Appointment
   {
      public uint IdAppointment { get; set; }
      public DateTime StartAppointment { get; set; }
      public DateTime EndAppointment { get; set; }
      
      public Doctor doctor { get; set; }
      public Patient patient { get; set; }

        public Appointment(uint idAppointment, DateTime startAppointment, DateTime endAppointment, Doctor doctor, Patient patient)
        {
            IdAppointment = idAppointment;
            StartAppointment = startAppointment;
            EndAppointment = endAppointment;
            this.doctor = doctor;
            this.patient = patient;
        }

        public Appointment()
        {
                
        }

        public Appointment(uint idAppointment)
        {
            idAppointment = idAppointment;
        }

        public Appointment(DateTime startAppointment, DateTime endAppointment, Doctor doctor, Patient patient)
        {
            StartAppointment = startAppointment;
            EndAppointment = endAppointment;
            this.doctor = doctor;
            this.patient = patient;
        }
    }
}