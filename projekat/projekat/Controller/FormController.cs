using Model;
using projekat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Controller
{
    public class FormController
    {
        private readonly FormService _service;
        public FormController(FormService service)
        {
            _service = service;
        }
        public IEnumerable<FormHospitalDTO> GetAllHospitalForms()
        {
            return _service.GetAllHospitalForms();
        }

        public IEnumerable<FormDoctorDTO> GetAllDoctorForms()
        {
            return _service.GetAllDoctorForms();
        }



    }
}
