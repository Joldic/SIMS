using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using projekat.View.ModelView;


namespace projekat.View.Converter
{
     class AppointmentConverter : AbstractConverter
    {
        public static AppointmentsView  ConvertAppointmentToAppointmentView(Appointment appointment) => new AppointmentsView
        {
            Id = appointment.Id,
            StartAppointment = appointment.StartAppointment,
            EndAppointment = appointment.EndAppointment,
            IdDoctor = appointment.IdDoctor,
            IdPatient = appointment.IdPatient,
            IdRoom = appointment.IdRoom
        };

        public static IList<AppointmentsView> ConvertAppointmentListToAppointmentViewList(IList<Appointment> appointments)
           => ConvertEntityListToViewList(appointments, ConvertAppointmentToAppointmentView);
    }
}
