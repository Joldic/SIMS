// File:    Allergen.cs
// Author:  joldic
// Created: 18 April 2022 12:43:53
// Purpose: Definition of Class Allergen

using System;

namespace Model
{
   public class Allergen
   {
      public uint Id { get; set; }
      public string Name { get; set; }

        public Allergen()
        {

        }

        public Allergen(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public Allergen(string name)
        {
            Name = name;
        }
    }
}