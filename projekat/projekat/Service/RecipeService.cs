// File:    RecipeService.cs
// Author:  joldic
// Created: 18 April 2022 13:12:42
// Purpose: Definition of Class RecipeService

using System;
using Repository;

using System.Collections.Generic;
using Model;
namespace Service
{
   public class RecipeService
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
      
      public RecipeRepository recipeRepository;
   
   }
}