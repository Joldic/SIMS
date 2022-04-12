using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aaaaaaaa.repository;

namespace aaaaaaaa.service
{
    public class RoomService
    {
        private readonly RoomRepository _roomRepo;

        public RoomService(RoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        internal IEnumerable<model.Room> GetAll()
        {
            var rooms = _roomRepo.GetAll();
            return rooms;
        }
        public model.Room FindRoom(uint id)
        {
            var room = _roomRepo.GetRoom(id);
            return room;
        }

        public model.Room ChangeRoom(model.Room room)
        {
            var room_ret = _roomRepo.UpdateRoom(room);
            return room_ret;
        }

        public Boolean DeleteRoom(uint id)
        {
            return _roomRepo.RemoveRoom(id);
        }

        public model.Room CreateNewRoom(model.Room room)
        {
            var room_ret = _roomRepo.AddRoom(room);
            return room_ret;
        }

        //public RoomRepository roomRepository;
    }
}
