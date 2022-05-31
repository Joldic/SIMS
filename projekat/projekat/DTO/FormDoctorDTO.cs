using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FormDoctorDTO
    {
        public uint Id { get; set; }
        public uint IdForm { get; set; }

        public uint Grade { get; set; }

        public uint PatientId { get; set; }

        public uint DoctorId { get; set; }

        public FormDoctorDTO()
        {

        }

        public FormDoctorDTO(uint id, uint idForm, uint grade, uint patientId, uint doctorId)
        {
            Id = id;
            IdForm = idForm;
            Grade = grade;
            PatientId = patientId;
            DoctorId = doctorId;
        }

        public FormDoctorDTO(uint idForm, uint grade, uint patientId, uint doctorId)
        {
            IdForm = idForm;
            Grade = grade;
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}
