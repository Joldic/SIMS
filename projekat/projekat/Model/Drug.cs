using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Drug
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public uint Weight { get; set; }

        public string Category { get; set; }

        public uint Quantity { get; set; }
        public Drug()
        {

        }

        public Drug(uint id, string name, uint weight, string caregory, uint quantity)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Category = caregory;
            Quantity = quantity;
        }

        public Drug(string name, uint weight, string caregory, uint quantity)
        {
            Name = name;
            Weight = weight;
            Category = caregory;
            Quantity = quantity;
        }


    }
}
