using System;
using Model;
using System.Collections.Generic;
using Service;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class RoomControler
   {
        private readonly RoomService _service;

        public RoomControler(RoomService service)
        {
            _service = service;
        }

        public Room CreateNewRoom(Room room)
        {
            return _service.CreateNewRoom(room);
        }

        public Room Readroom(uint id)
        {
            return _service.ReadRoom(id);
        }

        public Boolean DeleteRoom(uint id)
        {
            return _service.DeleteRoom(id);
        }

        public List<Room> GetAll()
        {
            return _service.GetAll();
        }
    }
}