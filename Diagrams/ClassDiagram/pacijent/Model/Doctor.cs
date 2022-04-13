using System;

namespace Model
{
   public class Doctor
   {
      public uint IdDoctor { get; set; }
      public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Specialization Specialization { get; set; }

        public Doctor()
        {

        }

        public Doctor(uint idDoctor)
        {
            IdDoctor = idDoctor;
        }

        public Doctor(uint idDoctor, string name, string surname, DateTime dateOfBirth, Specialization specialization)
        {
            IdDoctor = idDoctor;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
        }

        public Doctor(string name, string surname, DateTime dateOfBirth, Specialization specialization)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            Specialization = specialization;
        }
    } 
}