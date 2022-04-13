using System;

namespace Model
{
   public class Recipe
   {
      public uint IdRecipe { get; set; }
      public Patient Patient { get; set; }
      public String Medicine { get; set; }
      public Doctor Doctor { get; set; }

        public Recipe()
        {

        }

        public Recipe(uint id)
        {
            IdRecipe = id;
        }

        public Recipe(uint idRecipe, Patient patient, string medicine, Doctor doctor)
        {
            IdRecipe = idRecipe;
            Patient = patient;
            Medicine = medicine;
            Doctor = doctor;
        }

        public Recipe(Patient patient, string medicine, Doctor doctor)
        {
            Patient = patient;
            Medicine = medicine;
            Doctor = doctor;
        }


    }
}