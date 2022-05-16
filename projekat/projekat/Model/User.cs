using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Specialization Specialization { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public User()
        {

        }

        public User(uint id)
        {
            Id = id;
        }

        public User(uint id, string name, string surname, DateTime dateOfBirth, Specialization specialization, string adress, string email, Gender gender, string username, string password, Role role)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
            Adress = adress;
            Email = email;
            Gender = gender;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
