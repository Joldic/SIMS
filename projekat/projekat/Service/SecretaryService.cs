using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using projekat.Repository;
using Repository;
namespace projekat.Service
{
    public class SecretaryService
    {
        private readonly SecretaryRepository _repo;

        public SecretaryService(SecretaryRepository repo)
        {
            _repo = repo;
        }


        public Secretary GetSecretary(uint id)
        {
            return _repo.GetSecretary(id);
        }


        public IEnumerable<Secretary> GetAll()
        {
            return _repo.GetAll();
        }

        public Secretary FindSecretaryByUsername(string username)
        {
            return _repo.FindSecretaryByUsername(username);
        }
    }
}
