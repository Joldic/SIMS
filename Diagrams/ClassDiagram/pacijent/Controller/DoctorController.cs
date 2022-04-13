using Service;
using Repository;
using Model;
using System;
using System.Collections.Generic;
using pacijent.Service;

namespace pacijent.Controller
{
    internal class DoctorController
    {
        private readonly DoctorService _service;

        public DoctorController(DoctorService service)
        {
            _service = service;
        }

        public Doctor CreateNewDoctor(Doctor doctor)
        {
            return _service.CreateNewDoctor(doctor);
        }

        public Doctor ReadDoctor(uint id)
        {
            return _service.ReadDoctor(id);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _service.UpdateDoctor(doctor);
        }

        public Boolean DeleteDoctor(uint id)
        {
            return _service.DeleteDoctor(id);
        }
        public List<Doctor> GetAll()
        {
            return _service.GetAll();
        }




    }
}
