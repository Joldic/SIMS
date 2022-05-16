using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ingredient
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public Ingredient()
        {

        }

        public Ingredient(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public Ingredient(string name)
        {
            Name = name;
        }
    }
}
