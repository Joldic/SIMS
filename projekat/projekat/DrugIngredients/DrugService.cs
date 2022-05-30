using Model;
using projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Service
{
    public class DrugService
    {
        private readonly DrugRepository _repo;

        public DrugService(DrugRepository repo)
        {
            _repo = repo;
        }

        public Drug FindDrug(uint id)
        {
            return _repo.GetDrug(id);
        }

        public Drug ChangeDrug(Drug drug)
        {
            return _repo.UpdateDrug(drug);
        }

        public Boolean DeleteDrug(uint id)
        {
            return _repo.RemoveDrug(id);
        }

        public Boolean DeleteInvalidDrug(uint id)
        {
            return _repo.DeleteInvalidDrug(id);
        }

        public Drug CreateNewDrug(Drug drug)
        {
            return _repo.AddDrug(drug);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _repo.GetAll();
        }

        public IEnumerable<Drug> GetAllInvalidDrugs()
        {
            return _repo.GetAllInvalidDrugs();
        }

        public IEnumerable<DrugIngredientDTO> GetDrugIngredients()
        {
            return _repo.GetDrugIngredients();
        }

        public DrugIngredientDTO AddDrugIngredient(DrugIngredientDTO dto)
        {
            return _repo.AddDrugIngredient(dto);
        }

        public Boolean DeleteDrugIngredient(uint id)
        {
            return _repo.DeleteDrugIngredient(id);
        }

    }
}
