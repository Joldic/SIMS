using Model;
using projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Service
{
    public class ManagerService
    {
        private readonly ManagerRepository _repo;

        public ManagerService(ManagerRepository repo)
        {
            _repo = repo;
        }
        public Manager CreateNewManager(Manager doctor)
        {
            return _repo.AddManager(doctor);
        }

        public Manager FindManagerByUsername(string username)
        {
            return _repo.FindManagerByUsername(username);
        }

        public Manager ReadManager(uint id)
        {
            return _repo.GetManager(id);
        }

     

        public Manager UpdateManager(Manager doctor)
        {
            return _repo.UpdateManager(doctor);
        }

        public Boolean DeleteManager(uint id)
        {
            return _repo.RemoveManager(id);
        }

        public IEnumerable<Manager> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
