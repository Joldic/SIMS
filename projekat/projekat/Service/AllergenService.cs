// File:    AllergenService.cs
// Author:  joldic
// Created: 18 April 2022 13:01:45
// Purpose: Definition of Class AllergenService

using Repository;

using System.Collections.Generic;
using Model;

using System;

namespace Service
{
   public class AllergenService
   {
      public Model.Allergen CreateNewAllergen(Model.Allergen allergen)
      {
         throw new NotImplementedException();
      }
      
      public Model.Allergen GetAllergen(uint id)
      {
         throw new NotImplementedException();
      }
      
      public Model.Allergen UpdateAllergen(Model.Allergen allergen)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteAllergen(uint id)
      {
         throw new NotImplementedException();
      }
      
      public AllergenRepository allergenRepository;
   
   }
}