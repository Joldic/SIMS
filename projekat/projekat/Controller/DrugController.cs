using Model;
using projekat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Controller
{
    public class DrugController
    {
        private readonly DrugService _service;

        public DrugController(DrugService service)
        {
            _service = service;
        }
        public Drug CreateNewDrug(Drug drug)
        {
            return _service.CreateNewDrug(drug);
        }

        public Drug FindDrug(uint id)
        {
            return _service.FindDrug(id);
        }

        public Drug ChangeDrug(Drug drug)
        {
            return _service.ChangeDrug(drug);
        }

        public Boolean DeleteDrug(uint id)
        {
            return _service.DeleteDrug(id);
        }

        public Boolean DeleteInvalidDrug(uint id)
        {
            return _service.DeleteInvalidDrug(id);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _service.GetAll();
        }

        public IEnumerable<Drug> GetAllInvalidDrugs()
        {
            return _service.GetAllInvalidDrugs();
        }

        public IEnumerable<DrugIngredientDTO> GetDrugIngredients()
        {
            return _service.GetDrugIngredients();
        }

        public DrugIngredientDTO AddDrugIngredient(DrugIngredientDTO dto)
        {
            return _service.AddDrugIngredient(dto);
        }

        public Boolean DeleteDrugIngredient(uint id)
        {
            return _service.DeleteDrugIngredient(id);
        }




    }
}
