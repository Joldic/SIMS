// File:    AllergenController.cs
// Author:  joldic
// Created: 18 April 2022 12:54:14
// Purpose: Definition of Class AllergenController

using System;
using System.Collections.Generic;
using Model;
using Service;

namespace Controller
{
   public class AllergenController
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
      
      public AllergenService allergenService;
   
   }
}