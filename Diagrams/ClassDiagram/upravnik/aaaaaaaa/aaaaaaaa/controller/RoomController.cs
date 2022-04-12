using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaaaaaaa.service;

namespace aaaaaaaa.controller
{
    public class RoomController
    {
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }

        public model.Room CreateNewRoom(model.Room room)
        {
            return _service.CreateNewRoom(room);
        }

        public model.Room FindRoom(uint id)
        {
            return _service.FindRoom(id);
        }

        public model.Room ChangeRoom(model.Room room)
        {
            return _service.ChangeRoom(room);
        }

        public Boolean DeleteRoom(uint id)
        {
            return _service.DeleteRoom(id);
        }

        public IEnumerable<model.Room> GetAll()
        {
            return _service.GetAll();
        }

    }
}
