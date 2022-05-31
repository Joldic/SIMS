using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekat.Repository;

namespace projekat.Service
{
    public class FormService
    {
        private readonly FormRepository _repo;
        public FormService(FormRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<FormHospitalDTO> GetAllHospitalForms()
        {
            return _repo.GetAllHospitalForms();
        }

        public IEnumerable<FormDoctorDTO> GetAllDoctorForms()
        {
            return _repo.GetAllDoctorForms();
        }
    }
}
