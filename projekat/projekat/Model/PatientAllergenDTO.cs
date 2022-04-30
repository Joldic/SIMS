using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PatientAllergenDTO
    {

        public uint Id { get; set; }
        public uint PatientId { get; set; }

        public uint AllergenId { get; set; }

        public string AllergenName { get; set; }

        public PatientAllergenDTO()
        {

        }

        public PatientAllergenDTO(uint id)
        {
            Id = id;
        }

        public PatientAllergenDTO(uint id, uint patientId, uint allergenId, string allergenName) : this(id)
        {
            PatientId = patientId;
            AllergenId = allergenId;
            AllergenName = allergenName;
        }

        public PatientAllergenDTO(uint patientId, uint allergenId, string allergenName)
        {
            PatientId = patientId;
            AllergenId = allergenId;
            AllergenName = allergenName;
        }
    }
}
