using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aaaaaaaa.model
{
    public class Room
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public RoomType Type { get; set; }

        public uint SquareFootage { get; set; }

        public Room()
        {

        }

        public Room(uint id)
        {
            Id = id;
        }

        public Room(uint id, string name, RoomType type, uint squareFootage)
        {
            Id = id;
            Name = name;
            Type = type;
            SquareFootage = squareFootage;
        }

        public Room( string name, RoomType type, uint squareFootage)
        {
           
            Name = name;
            Type = type;
            SquareFootage = squareFootage;
        }
    }
}
