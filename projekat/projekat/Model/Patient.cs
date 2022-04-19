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

        public System.Collections.Generic.List<Allergen> allergen;
        private DateTime dateTime;

        public Patient()
        {

        }

        public Patient(uint id)
        {
            Id = id;
        }

        public Patient(uint id, string name, string surname, DateTime dateTime, string adress, string email, Gender gender)
        {
            Id = id;
            Name = name;
            Surname = surname;
            this.dateTime = dateTime;
            Adress = adress;
            Email = email;
            Gender = gender;
        }

        /// <summary>
        /// Property for collection of Allergen
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Allergen> Allergen
      {
         get
         {
            if (allergen == null)
               allergen = new System.Collections.Generic.List<Allergen>();
            return allergen;
         }
         set
         {
            RemoveAllAllergen();
            if (value != null)
            {
               foreach (Allergen oAllergen in value)
                  AddAllergen(oAllergen);
            }
         }
      }
      
      /// <summary>
      /// Add a new Allergen in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAllergen(Allergen newAllergen)
      {
         if (newAllergen == null)
            return;
         if (this.allergen == null)
            this.allergen = new System.Collections.Generic.List<Allergen>();
         if (!this.allergen.Contains(newAllergen))
            this.allergen.Add(newAllergen);
      }
      
      /// <summary>
      /// Remove an existing Allergen from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAllergen(Allergen oldAllergen)
      {
         if (oldAllergen == null)
            return;
         if (this.allergen != null)
            if (this.allergen.Contains(oldAllergen))
               this.allergen.Remove(oldAllergen);
      }
      
      /// <summary>
      /// Remove all instances of Allergen from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAllergen()
      {
         if (allergen != null)
            allergen.Clear();
      }
   
   }
}