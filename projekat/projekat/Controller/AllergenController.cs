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
        private readonly AllergenService _service;
        public AllergenController(AllergenService service)
        {
            _service = service;
        }
        public Model.Allergen CreateNewAllergen(Model.Allergen allergen)
        {
            return _service.CreateNewAllergen(allergen);
        }
      
        public Model.Allergen GetAllergen(uint id)
        {
            return _service.GetAllergen(id);
        }
      
        public Model.Allergen UpdateAllergen(Model.Allergen allergen)
        {
            return _service.UpdateAllergen(allergen);
        }
      
        public Boolean DeleteAllergen(uint id)
        {
            return _service.DeleteAllergen(id);  
        }
      

        public IEnumerable<Allergen> GetAll()
        {
            return _service.GetAll();
        }
      

        public IEnumerable<PatientAllergenDTO> GetPatientsAllergens()
        {
            return _service.GetPatientsAllergens();
        }

        public  Boolean DeletePatiensAllergen(uint id)
        {
            return _service.DeletePatiensAllergen(id);
        }

        public PatientAllergenDTO AddPatientsAllergen(PatientAllergenDTO dto)
        {
            return _service.AddPatientsAllergen(dto);
        }


   }
}