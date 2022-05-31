using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FormHospitalDTO
    {
        public uint Id { get; set; }

        public uint FormId { get; set; }

        public uint Grade { get; set; }

        public uint PatientId { get; set; }

        public FormHospitalDTO()
        {

        }

        public FormHospitalDTO(uint id, uint formId, uint grade, uint patientId)
        {
            Id = id;
            FormId = formId;
            Grade = grade;
            PatientId = patientId;
        }

        public FormHospitalDTO(uint formId, uint grade, uint patientId)
        {
            FormId = formId;
            Grade = grade;
            PatientId = patientId;
        }
    }
}
