using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sekretar.Model
{
    public class Patient
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }



        public Patient()
        {
                
        }

        public Patient(uint id)
        {
            Id = id;
        }

        public Patient(uint id, string name, string surname, string adress, string email, Gender gender, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }

        public Patient(string name, string surname, string adress, string email, Gender gender, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
    }
}
