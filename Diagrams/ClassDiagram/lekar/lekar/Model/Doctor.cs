using System;

namespace Model
{
   public class Doctor
   {
      private uint IdDoctor { get; set; }
      private String Name { get; set; }
        private String Surname { get; set; }
        private DateTime DateOfBirth { get; set; }
        private Specialization Specialization { get; set; }

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