using Model;
using projekat.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Controller
{
    public class IngredientController
    {
        private readonly IngredientService _service;
        public IngredientController(IngredientService service)
        {
            _service = service;
        }
        public Model.Ingredient CreateNewIngredient(Model.Ingredient ingredient)
        {
            return _service.CreateNewIngredient(ingredient);
        }

        public Model.Ingredient GetIngredient(uint id)
        {
            return _service.GetIngredient(id);
        }

        public Model.Ingredient UpdateIngredient(Model.Ingredient ingredient)
        {
            return _service.UpdateIngredient(ingredient);
        }

        public Boolean DeleteIngredient(uint id)
        {
            return _service.DeleteIngredient(id);
        }


        public IEnumerable<Ingredient> GetAll()
        {
            return _service.GetAll();
        }


    }
}
