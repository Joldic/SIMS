using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sekretar.Model;
using sekretar.View.Model;

namespace sekretar.View.Converter
{
    class PatientConverter : AbstractConverter
    {
        public static PatientView ConvertPatientToPatientView(Patient patient) => new PatientView
        {
            Id = patient.Id,
            PatientName = patient.Name,
            PatientSurname = patient.Surname,
            PatientAdress = patient.Adress,
            PatientEmail = patient.Email,
            PatientGender = patient.Gender,
            PatientDateOfBirth = patient.DateOfBirth
        };

        public static IList<PatientView> ConvertPatientListToPatientViewList(IList<Patient> patients)
           => ConvertEntityListToViewList(patients, ConvertPatientToPatientView);

    }
}
