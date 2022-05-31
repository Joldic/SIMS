using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Form
    {
        public uint Id { get; set; }
        public string Question1  { get; set; }
        public string Question2  { get; set; }
        public string Question3  { get; set; }

        public Form()
        {

        }

        public Form(uint id, string question1, string question2, string question3)
        {
            Id = id;
            Question1 = question1;
            Question2 = question2;
            Question3 = question3;
        }
    }
}
