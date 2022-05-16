using Model;
using projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Service
{
    public class UserService
    {
        private readonly UserRepository _repo;

        public UserService(UserRepository repo)
        {
            _repo = repo;
        }


        public User GetUser(uint id)
        {
            return _repo.GetUser(id);
        }


        public IEnumerable<User> GetAll()
        {
            return _repo.GetAll();
        }

        public User FindUserByUsername(string username)
        {
            return _repo.FindUserByUsername(username);
        }
    }
}
