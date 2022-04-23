// File:    Manager.cs
// Author:  joldic
// Created: 18 April 2022 12:17:42
// Purpose: Definition of Class Manager


using System;

namespace Model 
{
   public class Manager
{
        public uint Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Adress { get; set; }
        public String Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Manager()
        {

        }

        public Manager(uint id)
        {
            Id = id;
        }

        public Manager(uint id, string username, string password, string name, string surname, string adress, string email, Gender gender, DateTime dateOfBirth) : this(id)
        {
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Username = username;
            Password = password;
        }
    }
}