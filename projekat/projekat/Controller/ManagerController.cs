using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Model;
using Service;
using projekat.Service;

namespace projekat.Controller
{
    public class ManagerController
    {
        private readonly ManagerService _service;

        public ManagerController(ManagerService service)
        {
            _service = service;
        }
        public Manager CreateNewManager(Manager doctor)
        {
            return _service.CreateNewManager(doctor);
        }
      
        public Manager ReadManager(uint id)
        {
            return _service.ReadManager(id);
        }

        public Manager FindManagerByUsername(string username)
        {
            return _service.FindManagerByUsername(username);
        }

        public Manager UpdateManager(Manager doctor)
        {
            return _service.UpdateManager(doctor);
        }

        public Boolean DeleteManager(uint id)
        {
            return _service.DeleteManager(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _service.GetAll();
        }
    }
}
