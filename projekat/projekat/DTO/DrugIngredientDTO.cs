using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DrugIngredientDTO
    {
        public uint Id { get; set; }

        public uint DrugId { get; set; }

        public uint IngredientId { get; set; }

        public string Name { get; set; }

        public DrugIngredientDTO()
        {

        }

        public DrugIngredientDTO(uint id, uint drugId, uint ingredientId, string name)
        {
            Id = id;
            DrugId = drugId;
            IngredientId = ingredientId;
            Name = name;
        }

        public DrugIngredientDTO(uint drugId, uint ingredientId, string name)
        {
            DrugId = drugId;
            IngredientId = ingredientId;
            Name = name;
        }
    }
}
