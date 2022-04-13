using System;
using Model;
using System.Collections.Generic;
using Repository;

namespace Service
{
   public class RoomService
   {
        private readonly RoomRepository _roomRepo;

        public RoomService(RoomRepository roomRepo)
        {
            _roomRepo = roomRepo;
        }

        public Room CreateNewRoom(Room room)
        {
            var ret = _roomRepo.AddRoom(room);
            return ret;
        }

        public Room ReadRoom(uint id)
        {
            var ret = _roomRepo.GetRoom(id);
            return ret;
        }

        public Room UpdateRoom(Room room)
        {
            var ret = _roomRepo.UpdateRoom(room);
            return ret;
        }

        public Boolean DeleteRoom(uint id)
        {
            return _roomRepo.RemoveRoom(id);
        }

        internal List<Room> GetAll()
        {
            var rooms = _roomRepo.GetAll();
            return rooms;
        }
    }
}