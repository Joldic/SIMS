using System;
using System.Collections.Generic;
using lekar.Repository;
using Model;


namespace pacijent.Service
{
    public class DoctorService
    {
        private readonly DoctorRepository _doctorRepo;

        public DoctorService(DoctorRepository doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public Doctor CreateNewDoctor(Doctor doctor)
        {
            var ret = _doctorRepo.AddDoctor(doctor);
            return ret;
        }

        public Doctor ReadDoctor(uint id)
        {
            var ret = _doctorRepo.GetDoctor(id);
            return ret;
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            var ret = _doctorRepo.UpdateDoctor(doctor);
            return ret;
        }

        public Boolean DeleteDoctor(uint id)
        {
            return _doctorRepo.RemoveDoctor(id);
        }

        internal List<Doctor> GetAll()
        {
            var doctors = _doctorRepo.GetAll();
            return doctors;
        }
    }
}
