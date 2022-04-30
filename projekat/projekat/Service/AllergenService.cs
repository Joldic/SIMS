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
        private readonly AllergenRepository _repo;
        public AllergenService(AllergenRepository repository)
        {
            _repo = repository;
        }
        public Model.Allergen CreateNewAllergen(Model.Allergen allergen)
        {
            return _repo.CreateNewAllergen(allergen);
        }

        public Model.Allergen GetAllergen(uint id)
        {
            return _repo.GetAllergen(id);
        }

        public Model.Allergen UpdateAllergen(Model.Allergen allergen)
        {
            return _repo.UpdateAllergen(allergen);
        }

        public Boolean DeleteAllergen(uint id)
        {
            return _repo.DeleteAllergen(id);
        }

        public IEnumerable<Allergen> GetAll()
        {
            return _repo.GetAll();
        }


        public IEnumerable<PatientAllergenDTO> GetPatientsAllergens()
        {
            return _repo.GetPatientsAllergens();
        }

        public Boolean DeletePatiensAllergen(uint id)
        {
            return _repo.DeletePatiensAllergen(id);
        }

        public PatientAllergenDTO AddPatientsAllergen(PatientAllergenDTO dto)
        {
            return _repo.AddPatientsAllergen(dto);
        }
    }
}