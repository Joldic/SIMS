// File:    Appointment.cs
// Author:  User
// Created: Monday, April 11, 2022 4:25:39 PM
// Purpose: Definition of Class Appointment

using System;

namespace Model
{
   public class Appointment
   {
        public uint  Id { get; set; }
        public DateTime StartAppointment { get; set; }
        public DateTime EndAppointment { get; set; }

        public Doctor Doctor { get; set; }

        public uint IdDoctor { get; set; }

        public Patient Patient { get; set; }

        public uint IdPatient { get; set; }
        public Anamnesis Anamnesis { get; set; }

        public Room Room { get; set; }

        public uint IdRoom { get; set; }


        public string RoomName { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }

        public Appointment()
        {

        }

        public Appointment(uint id)
        {
            Id = id;
        }

        public Appointment(uint id, DateTime startAppointment, DateTime endAppointment) 
        {
            Id = id;
            StartAppointment = startAppointment;
            EndAppointment = endAppointment;
        }

        public Appointment(uint id, DateTime startAppointment, DateTime endAppointment, uint idDoctor, uint idPatient, uint idRoom) : this(id, startAppointment, endAppointment)
        {
            IdDoctor = idDoctor;
            IdPatient = idPatient;
            IdRoom = idRoom;
        }
    }
}