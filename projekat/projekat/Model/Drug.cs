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

        public Drug()
        {

        }

        public Drug(uint id, string name, uint weight, string caregory)
        {
            Id = id;
            Name = name;
            Weight = weight;
            Category = caregory;
        }

        public Drug(string name, uint weight, string caregory)
        {
            Name = name;
            Weight = weight;
            Category = caregory;
        }
    }
}
