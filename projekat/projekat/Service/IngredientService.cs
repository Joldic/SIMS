using Model;
using projekat.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekat.Service
{
    public class IngredientService
    {
        private readonly IngredientRepository _repo;
        public IngredientService(IngredientRepository repository)
        {
            _repo = repository;
        }
        public Model.Ingredient CreateNewIngredient(Model.Ingredient ingredient)
        {
            return _repo.CreateNewIngredient(ingredient);
        }

        public Model.Ingredient GetIngredient(uint id)
        {
            return _repo.GetIngredient(id);
        }

        public Model.Ingredient UpdateIngredient(Model.Ingredient ingredient)
        {
            return _repo.UpdateIngredient(ingredient);
        }

        public Boolean DeleteIngredient(uint id)
        {
            return _repo.DeleteIngredient(id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _repo.GetAll();
        }


    }
}
