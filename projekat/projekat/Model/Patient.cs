// File:    Patient.cs
// Author:  3500x
// Created: 12 April 2022 18:51:49
// Purpose: Definition of Class Patient


using System;

namespace Model
{
   public class Patient
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

        public string Password { get; set; }
        public string Username { get; set; }

        public System.Collections.Generic.List<Allergen> allergen;
        private string patientName1;
        private string patientSurname;
        private DateTime patientBirthDate;
        private string patientAdress;
        private object p;
        private string patientEmail;
        private Gender patientGender;
        private string v;
        private string patientName2;

        public Patient()
        {

        }

        public Patient(uint id)
        {
            Id = id;
        }

        public Patient(uint id, string name, string surname, DateTime dateOfBirth, string adress, string email, Gender gender)
        {
            Id = id;
            Name = name;
            Surname = surname;
            this.DateOfBirth = dateOfBirth;
            Adress = adress;
            Email = email;
            Gender = gender;
        }

        public Patient(string name, string surname, DateTime dateOfBirth, string adress, string email, Gender gender, string password, string username)
        {
            Name = name;
            Surname = surname;
            this.DateOfBirth = dateOfBirth;
            Adress = adress;
            Email = email;
            Gender = gender;
            Password = password;
            Username = username;

        }

        public Patient(uint id, string name, string surname, DateTime dateOfBirth, string adress, string email, Gender gender, string password, string username)
        {
            Id = id;
            Name = name;
            Surname = surname;
            this.DateOfBirth = dateOfBirth;
            Adress = adress;
            Email = email;
            Gender = gender;
            Password = password;
            Username = username;
         
        }

        
    }
}