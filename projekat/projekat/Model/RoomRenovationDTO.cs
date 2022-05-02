using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoomRenovationDTO
    {
        public uint Id { get; set; }
        public uint IdRoom { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public RoomRenovationDTO()
        {

        }

        public RoomRenovationDTO(uint id, uint idRoom, DateTime start, DateTime end)
        {
            Id = id;
            IdRoom = idRoom;
            Start = start;
            End = end;
        }

        public RoomRenovationDTO(uint idRoom, DateTime start, DateTime end)
        {
            IdRoom = idRoom;
            Start = start;
            End = end;
        }
    }
}
