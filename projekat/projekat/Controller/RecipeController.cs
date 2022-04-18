// File:    RecipeController.cs
// Author:  joldic
// Created: 18 April 2022 13:10:04
// Purpose: Definition of Class RecipeController

using System;
using System.Collections.Generic;
using Model;
using Service;
namespace Controller
{
   public class RecipeController
   {
      public Model.Recipe CreateNewRecipe(Model.Recipe recipe)
      {
         throw new NotImplementedException();
      }
      
      public Model.Recipe GetRecipe(uint id)
      {
         throw new NotImplementedException();
      }
      
      public Model.Recipe UpdateRecipe(Model.Recipe recipe)
      {
         throw new NotImplementedException();
      }
      
      public Boolean DeleteRecipe(uint id)
      {
         throw new NotImplementedException();
      }
      
      public RecipeService recipeService;
   
   }
}