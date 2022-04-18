// File:    Secretary.cs
// Author:  joldic
// Created: 18 April 2022 12:18:00
// Purpose: Definition of Class Secretary

using Model;
using System;

namespace Model
{
   public class Secretary
    {
        public uint Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Adress { get; set; }
        public String Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public Role Role { get; set; }


        public Secretary()
        {

        }

        public Secretary(uint id)
        {
            Id = id;
        }

        public Secretary(uint id, string username, string password, string name, string surname, string adress, string email, Gender gender, DateTime dateOfBirth, Role role)

        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public Secretary(string username, string password, string name, string surname, string adress, string email, Gender gender, DateTime dateOfBirth, Role role)
        {
            Username = username; // test
            Password = password;
            Name = name;
            Surname = surname;
            Adress = adress;
            Email = email;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Role = role;
        }
    }
}