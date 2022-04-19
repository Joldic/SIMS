using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using projekat.Repository;


namespace projekat.Service
{
    public class DoctorService
    {
        private readonly DoctorRepository _repo;

        public DoctorService(DoctorRepository repo)
        {
            _repo = repo;
        }
        public Doctor CreateNewDoctor(Doctor doctor)
        {
            return _repo.AddDoctor(doctor);
        }

        public Doctor ReadDoctor(uint id)
        {
            return _repo.GetDoctor(id);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _repo.UpdateDoctor(doctor);
        }

        public Boolean DeleteDoctor(uint id)
        {
            return _repo.RemoveDoctor(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
