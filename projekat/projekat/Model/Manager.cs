// File:    Manager.cs
// Author:  joldic
// Created: 18 April 2022 12:17:42
// Purpose: Definition of Class Manager


using System;

namespace Model 
{
   public class Manager
{
      private uint Id { get; set; }
      private String Name { get; set; }
      private String Surname { get; set; }
      private String Adress { get; set; }
      private String Email { get; set; }
      private Gender Gender { get; set; }
      private DateTime DateOfBirth { get; set; }

        public Manager()
        {

        }

        public Manager(uint id, string name, string surname, string adress, string email, Gender gender, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
    }
}